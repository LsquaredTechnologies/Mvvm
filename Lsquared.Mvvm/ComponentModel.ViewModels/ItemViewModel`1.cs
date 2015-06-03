// <copyright file="ItemViewModel`2.cs" company="LSQUARED">
// Copyright © 2008-2015
// </copyright>

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lsquared.ComponentModel.ViewModels
{
    public abstract class ItemViewModel<TModel> : SelectableViewModel, IItemViewModel<TModel>, IEquatable<ItemViewModel<TModel>>, IValidatableObject
        where TModel : class
    {
        [field: NonSerialized]
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        object IItemViewModel.Model
        {
            get { return Model; }
            set { Model = (TModel)value; }
        }

        [PropertyChanged.DoNotSetChanged]
        public TModel Model
        {
            get { return _model; }
            set
            {
                if (value == null) { throw new ArgumentNullException("model", "Cannot set 'ItemViewModel.Model' to null"); }
                CancelEdit();
                _model = value;
            }
        }

        [PropertyChanged.DoNotSetChanged]
        public bool IsChanged { get; set; }

        [PropertyChanged.DoNotSetChanged]
        public bool IsEditing { get; set; }

        [PropertyChanged.DoNotSetChanged]
        public bool IsDeleting { get; set; }

        [PropertyChanged.DoNotNotify]
        public bool HasErrors
        {
            get { return _errors.Any(); }
        }

        protected ItemViewModel()
        {
        }

        protected ItemViewModel(TModel model)
        {
            _model = model;
            CancelEdit();
        }

        public void BeginEdit()
        {
            IsEditing = true;
            OnBeginEdit();
        }

        public void CancelEdit()
        {
            IsEditing = false;
            IsChanged = false;
        }

        public void EndEdit()
        {
            if (Validate())
            {
                OnEndEdit();
                IsEditing = false;
            }
        }

        public void AddError(ValidationException exception)
        {
            Contract.Requires(exception != null);

            AddError(exception.ValidationResult);
        }

        public void AddError(ValidationResult result)
        {
            Contract.Requires(result != null);

            _errors.Add(result);
            foreach (var propertyName in result.MemberNames)
            {
                OnErrorsChanged(propertyName);
            }
        }

        public void RemoveError(ValidationResult result)
        {
            Contract.Requires(result != null);

            _errors.Remove(result);
            foreach (var propertyName in result.MemberNames)
            {
                OnErrorsChanged(propertyName);
            }
        }

        public bool Validate()
        {
            lock (critical)
            {
                _errors.Clear();
                var results = new List<ValidationResult>();
                try
                {
                    return ViewModelValidator.TryValidateObject(this, new ValidationContext(this, null, null), results);
                }
                finally
                {
                    results.ForEach((vr) => AddError(vr));
                }
            }
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return from error in _errors
                   where error.MemberNames.Contains(propertyName)
                   select error;
        }

        public bool Equals(ItemViewModel<TModel> other)
        {
            if (object.ReferenceEquals(null, other)) { return false; }
            if (object.ReferenceEquals(this, other)) { return true; }
            if (object.ReferenceEquals(Model, other.Model)) { return true; }
            return object.Equals(Model, other.Model);
        }

        public bool Equals(TModel model)
        {
            if (object.ReferenceEquals(null, model)) { return false; }
            if (object.ReferenceEquals(Model, model)) { return true; }
            return object.Equals(Model, model);
        }

        public override bool Equals(object obj)
        {
            var other = obj as ItemViewModel<TModel>;
            var model = obj as TModel;
            return Equals(other) || Equals(model);
        }

        public override int GetHashCode()
        {
            return Model == null ? base.GetHashCode() : Model.GetHashCode();
        }


        public static implicit operator TModel(ItemViewModel<TModel> vm)
        {
            Contract.Requires(vm != null);
            return vm._model;
        }

        public TModel ToModel()
        {
            return _model;
        }
        
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            CustomValidation(results);
            return results;
        }

        protected virtual void CustomValidation(IList<ValidationResult> results)
        {
        }

        protected override async void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            await ValidateAsync();
        }

        protected abstract void OnBeginEdit();

        protected abstract void OnCancelEdit();

        protected abstract void OnEndEdit();

        protected virtual void OnIsChangedChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        protected virtual void OnModelChanged()
        {
        }

        protected virtual void OnModelChanging()
        {
        }

        private void OnErrorsChanged(string propertyName)
        {
            var h = ErrorsChanged;
            if (h == null) { return; }
            h(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private async Task ValidateAsync()
        {
#if NET40
            await TaskEx.Run(() => Validate());
#else
            await Task.Run(() => Validate());
#endif
        }

        private TModel _model;

        private readonly HashSet<ValidationResult> _errors = new HashSet<ValidationResult>();
        private readonly object critical = new object();
    }
}
