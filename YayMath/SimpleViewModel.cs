using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace YayMath
{
    public class SimpleViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged<T> (Expression<Func<T>> propExpr)
        {
            var prop = (PropertyInfo)((MemberExpression)propExpr.Body).Member;
            this.RaisePropertyChanged (prop.Name);
        }

        protected void RaisePropertyChanged ([CallerMemberName] string propertyName = "")
        {
            PropertyChanged.Invoke (this, new PropertyChangedEventArgs (propertyName));
        }

        protected void RaiseAllPropertiesChanged ()
        {
            PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (string.Empty));
        }
    }
}

