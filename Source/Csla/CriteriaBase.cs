//-----------------------------------------------------------------------
// <copyright file="CriteriaBase.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: https://cslanet.com
// </copyright>
// <summary>Base type from which Criteria classes can be</summary>
//-----------------------------------------------------------------------

using Csla.Core;
using System.Linq.Expressions;
using Csla.Reflection;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;

namespace Csla
{
  /// <summary>
  /// Base type from which Criteria classes can be
  /// derived in a business class. 
  /// </summary>
  [Serializable]
  public abstract class CriteriaBase<
#if NET8_0_OR_GREATER
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
#endif
    T> : ManagedObjectBase
    where T : CriteriaBase<T>
  {
    /// <summary>
    /// Initializes empty CriteriaBase. The type of
    /// business object to be created by the DataPortal
    /// MUST be supplied by the subclass.
    /// </summary>
    protected CriteriaBase()
    { }

    #region  Register Properties

    /// <summary>
    /// Indicates that the specified property belongs
    /// to the business object type.
    /// </summary>
    /// <typeparam name="P">
    /// Type of property.
    /// </typeparam>
    /// <param name="info">
    /// PropertyInfo object for the property.
    /// </param>
    /// <returns>
    /// The provided IPropertyInfo object.
    /// </returns>
    protected static PropertyInfo<P> RegisterProperty<
#if NET8_0_OR_GREATER
      [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
#endif
      P>(PropertyInfo<P> info)
    {
      return Core.FieldManager.PropertyInfoManager.RegisterProperty<P>(typeof(T), info);
    }

    /// <summary>
    /// Indicates that the specified property belongs
    /// to the business object type.
    /// </summary>
    /// <typeparam name="P">Type of property</typeparam>
    /// <param name="propertyName">Property name from nameof()</param>
    protected static PropertyInfo<P> RegisterProperty<
#if NET8_0_OR_GREATER
      [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
#endif
      P>(string propertyName)
    {
      return RegisterProperty(Core.FieldManager.PropertyInfoFactory.Factory.Create<P>(typeof(T), propertyName));
    }

    /// <summary>
    /// Indicates that the specified property belongs
    /// to the business object type.
    /// </summary>
    /// <typeparam name="P">Type of property</typeparam>
    /// <param name="propertyLambdaExpression">Property Expression</param>
    protected static PropertyInfo<P> RegisterProperty<
#if NET8_0_OR_GREATER
      [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
#endif
      P>(Expression<Func<T, object>> propertyLambdaExpression)
    {
      PropertyInfo reflectedPropertyInfo = Reflect<T>.GetProperty(propertyLambdaExpression);
      return RegisterProperty<P>(reflectedPropertyInfo.Name);
    }

    /// <summary>
    /// Indicates that the specified property belongs
    /// to the business object type.
    /// </summary>
    /// <typeparam name="P">Type of property</typeparam>
    /// <param name="propertyName">Property name from nameof()</param>
    /// <param name="relationship">Relationship with
    /// referenced object.</param>
    protected static PropertyInfo<P> RegisterProperty<
#if NET8_0_OR_GREATER
      [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
#endif
      P>(string propertyName, RelationshipTypes relationship)
    {
      return RegisterProperty(Core.FieldManager.PropertyInfoFactory.Factory.Create<P>(typeof(T), propertyName, string.Empty, relationship));
    }

    /// <summary>
    /// Indicates that the specified property belongs
    /// to the business object type.
    /// </summary>
    /// <typeparam name="P">Type of property</typeparam>
    /// <param name="propertyLambdaExpression">Property Expression</param>
    /// <param name="relationship">Relationship with
    /// referenced object.</param>
    protected static PropertyInfo<P> RegisterProperty<
#if NET8_0_OR_GREATER
      [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
#endif
      P>(Expression<Func<T, object>> propertyLambdaExpression, RelationshipTypes relationship)
    {
      PropertyInfo reflectedPropertyInfo = Reflect<T>.GetProperty(propertyLambdaExpression);
      return RegisterProperty<P>(reflectedPropertyInfo.Name, relationship);
    }

    /// <summary>
    /// Indicates that the specified property belongs
    /// to the business object type.
    /// </summary>
    /// <typeparam name="P">Type of property</typeparam>
    /// <param name="propertyName">Property name from nameof()</param>
    /// <param name="friendlyName">Friendly description for a property to be used in databinding</param>
    protected static PropertyInfo<P> RegisterProperty<
#if NET8_0_OR_GREATER
      [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
#endif
      P>(string propertyName, string friendlyName)
    {
      return RegisterProperty(Core.FieldManager.PropertyInfoFactory.Factory.Create<P>(typeof(T), propertyName, friendlyName));
    }

    /// <summary>
    /// Indicates that the specified property belongs
    /// to the business object type.
    /// </summary>
    /// <typeparam name="P">Type of property</typeparam>
    /// <param name="propertyLambdaExpression">Property Expression</param>
    /// <param name="friendlyName">Friendly description for a property to be used in databinding</param>
    protected static PropertyInfo<P> RegisterProperty<
#if NET8_0_OR_GREATER
      [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
#endif
      P>(Expression<Func<T, object>> propertyLambdaExpression, string friendlyName)
    {
      PropertyInfo reflectedPropertyInfo = Reflect<T>.GetProperty(propertyLambdaExpression);
      return RegisterProperty<P>(reflectedPropertyInfo.Name, friendlyName);
    }

    /// <summary>
    /// Indicates that the specified property belongs
    /// to the business object type.
    /// </summary>
    /// <typeparam name="P">Type of property</typeparam>
    /// <param name="propertyName">Property name from nameof()</param>
    /// <param name="friendlyName">Friendly description for a property to be used in databinding</param>
    /// <param name="defaultValue">Default Value for the property</param>
    protected static PropertyInfo<P> RegisterProperty<
#if NET8_0_OR_GREATER
      [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
#endif
      P>(string propertyName, string friendlyName, P defaultValue)
    {
      return RegisterProperty(Core.FieldManager.PropertyInfoFactory.Factory.Create<P>(typeof(T), propertyName, friendlyName, defaultValue));
    }

    /// <summary>
    /// Indicates that the specified property belongs
    /// to the business object type.
    /// </summary>
    /// <typeparam name="P">Type of property</typeparam>
    /// <param name="propertyLambdaExpression">Property Expression</param>
    /// <param name="friendlyName">Friendly description for a property to be used in databinding</param>
    /// <param name="defaultValue">Default Value for the property</param>
    protected static PropertyInfo<P> RegisterProperty<
#if NET8_0_OR_GREATER
      [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
#endif
      P>(Expression<Func<T, object>> propertyLambdaExpression, string friendlyName, P defaultValue)
    {
      PropertyInfo reflectedPropertyInfo = Reflect<T>.GetProperty(propertyLambdaExpression);
      return RegisterProperty(reflectedPropertyInfo.Name, friendlyName, defaultValue);
    }

    /// <summary>
    /// Indicates that the specified property belongs
    /// to the business object type.
    /// </summary>
    /// <typeparam name="P">Type of property</typeparam>
    /// <param name="propertyName">Property name from nameof()</param>
    /// <param name="friendlyName">Friendly description for a property to be used in databinding</param>
    /// <param name="defaultValue">Default Value for the property</param>
    /// <param name="relationship">Relationship with
    /// referenced object.</param>
    protected static PropertyInfo<P> RegisterProperty<
#if NET8_0_OR_GREATER
      [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
#endif
      P>(string propertyName, string friendlyName, P defaultValue, RelationshipTypes relationship)
    {
      return RegisterProperty(Core.FieldManager.PropertyInfoFactory.Factory.Create<P>(typeof(T), propertyName, friendlyName, defaultValue, relationship));
    }

    /// <summary>
    /// Indicates that the specified property belongs
    /// to the business object type.
    /// </summary>
    /// <typeparam name="P">Type of property</typeparam>
    /// <param name="propertyLambdaExpression">Property Expression</param>
    /// <param name="friendlyName">Friendly description for a property to be used in databinding</param>
    /// <param name="defaultValue">Default Value for the property</param>
    /// <param name="relationship">Relationship with
    /// referenced object.</param>
    protected static PropertyInfo<P> RegisterProperty<
#if NET8_0_OR_GREATER
      [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
#endif
      P>(Expression<Func<T, object>> propertyLambdaExpression, string friendlyName, P defaultValue, RelationshipTypes relationship)
    {
      PropertyInfo reflectedPropertyInfo = Reflect<T>.GetProperty(propertyLambdaExpression);
      return RegisterProperty(reflectedPropertyInfo.Name, friendlyName, defaultValue, relationship);
    }

    #endregion
  }
}