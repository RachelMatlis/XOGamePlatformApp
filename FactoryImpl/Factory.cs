using InfraAttributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;


namespace FactoryImpl
{
    public class Factory
    {
        
        private static Factory _instance = null;
        Dictionary<Type, Type> _type2type; 
        public static Factory getInstance()
        {
            //Will return an instance of XOFactory 
            if (_instance == null)
            {
                _instance = new Factory();
            }
            return _instance; 
        }
        public void Register(Type interfaceType,Type instanceType)
        {
            _type2type.Add(interfaceType, instanceType); 
        }

        public void Register<interfaceTypeT,instanceTypeT>()
        {
            Register(typeof(interfaceTypeT), typeof(instanceTypeT)); 
        }


        private Factory()
        {
            _type2type = new Dictionary<Type,Type>();

            
            //load dlls from a folder 
            var files = Directory.GetFiles("services", "*.dll");
            foreach(var file in files)
            {
                var assembly = Assembly.LoadFrom(file);
                foreach (var type in assembly.GetTypes())
                {
                    var registerAttribute = type.GetCustomAttribute<RegisterAttribute>();
                    if (registerAttribute != null)
                    {
                        Register(registerAttribute.InterfaceType, type);
                    }
                }
            }

            //foreach dll get types
            //foreach type if register attribut exists then register type 




        }
        public List<Type> GetAll<T>()
        {
            var retval = new List<Type>();
            foreach (Type t in _type2type.Keys)
            {
                if (typeof(T).IsAssignableFrom(t))
                {
                    retval.Add(t); 
                }
            }
            return retval; 
        }
        public T Create<T>(params  object [] parameters )
        {
            var retval = default(T);
            if (_type2type.ContainsKey(typeof(T)))
            {
                var type = _type2type[typeof(T)];

                retval = (T)Activator.CreateInstance(type, parameters);
                
            }
           

            return retval; 
        }
        public IT Create<IT>(Type interfaceType, params object[] parameters)
        {
            var retval = default(IT);
            if (_type2type.ContainsKey(interfaceType))
            {
                var type = _type2type[interfaceType];

                retval = (IT)Activator.CreateInstance(type, parameters);

            }
            return retval;
        }
      
       
    }
}
