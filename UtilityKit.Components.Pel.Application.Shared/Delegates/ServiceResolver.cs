namespace UtilityKit.Components.Pel.Application.Shared.Delegates;
public delegate TInterface ServiceResolver<TInterface>(string key) where TInterface : class;