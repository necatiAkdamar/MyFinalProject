using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception//bu bir attribute
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)//bana validator type ı ver
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//gönderilen validatortype Ivalidator değilse
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;// hata oluşmazsa gönderilen productvalidator _validatortype oluyor
        }
        protected override void OnBefore(IInvocation invocation)//methodinterception onbefore da bu kod çalışacağı için override ettik
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//burası bir reflection yani çalışma anında çalışacak//productvalidator un bir instanceını oluştur _validatortype
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//productvalidator un basetype ını bul generic argümanlarından ilkini bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//methodun parametrelerini bul, validator un tipine eşit olan parametreleri bul
            foreach (var entity in entities)//herbirini tek tek gez
            {
                ValidationTool.Validate(validator, entity);//validation tool u kullanarak validate et
            }
        }
    }
}
