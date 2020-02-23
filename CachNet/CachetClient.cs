using CachNet.Entities;
using CachNet.Net;
using RestEase;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace CachNet
{
    public class CachetClient : ICachetClient, IDisposable
    {
        public static string WrapperVersion { get; } =
            typeof(CachetClient).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ??
            typeof(CachetClient).GetTypeInfo().Assembly.GetName().Version.ToString(3) ??
            "Unknown";

        private readonly ICachetClient _api;

        public CachetClient(string ApiBase) : this(ApiBase, null) { }

        public CachetClient(string ApiBase, string ApiToken)
        {
            BaseUrl = ApiBase;

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri($"{ApiBase}/api/v1/")
            };
            httpClient.DefaultRequestHeaders.Add("User-Agent", $"CachNet/v{WrapperVersion} (https://github.com/exsersewo/CachNet)");

            if(ApiToken != null)
            {
                httpClient.DefaultRequestHeaders.Add("X-Cachet-Token", ApiToken);
            }

            _api = RestClient.For<ICachetClient>(httpClient);
        }

        public string BaseUrl { get; private set; }

        public void Dispose() => _api.Dispose();

        public Task<ResponseData<Component>> AddComponentAsync(PostComponent component)
        {
            return _api.AddComponentAsync(component);
        }

        public Task<ResponseData<ComponentGroup>> AddComponentGroupAsync(PostComponentGroup group)
        {
            return _api.AddComponentGroupAsync(group);
        }

        public Task<ResponseData<IncidentUpdate>> AddIncidentUpdateAsync(int incidentId, PostIncidentUpdate update)
        {
            return _api.AddIncidentUpdateAsync(incidentId, update);
        }

        public Task<ResponseData<Incident>> AddIncidentAsync(PostIncident incidient)
        {
            return _api.AddIncidentAsync(incidient);
        }

        public Task<ResponseData<Metric>> AddMetricAsync(PostMetric metric)
        {
            return _api.AddMetricAsync(metric);
        }

        public Task<ResponseData<IReadOnlyList<MetricPoint>>> AddMetricPointAsync(int metricId, PostMetricPoint metricPoint)
        {
            return _api.AddMetricPointAsync(metricId, metricPoint);
        }

        public Task<ResponseData<Subscriber>> AddSubscriberAsync(PostSubscriber subscriber)
        {
            return _api.AddSubscriberAsync(subscriber);
        }

        public Task DeleteComponentAsync(int componentId)
        {
            return _api.DeleteComponentAsync(componentId);
        }

        public Task DeleteComponentGroupAsync(int groupId)
        {
            return _api.DeleteComponentGroupAsync(groupId);
        }

        public Task DeleteIncidentAsync(int incidentId)
        {
            return _api.DeleteIncidentAsync(incidentId);
        }

        public Task DeleteIncidentUpdateAsync(int incidentId, int updateId)
        {
            return _api.DeleteIncidentUpdateAsync(incidentId, updateId);
        }

        public Task DeleteMetricAsync(int metricId)
        {
            return _api.DeleteMetricAsync(metricId);
        }

        public Task DeleteMetricPointAsync(int metricId, int pointId)
        {
            return _api.DeleteMetricPointAsync(metricId, pointId);
        }

        public Task DeleteSubscriberAsync(int subscriberId)
        {
            return _api.DeleteSubscriberAsync(subscriberId);
        }

        public Task<ResponseData<IReadOnlyList<ComponentGroup>>> GetAllComponentGroupsAsync()
        {
            return _api.GetAllComponentGroupsAsync();
        }

        public Task<ResponseData<IReadOnlyList<Component>>> GetAllComponentsAsync()
        {
            return _api.GetAllComponentsAsync();
        }

        public Task<ResponseData<IReadOnlyList<Incident>>> GetAllIncidentsAsync()
        {
            return _api.GetAllIncidentsAsync();
        }

        public Task<ResponseData<IReadOnlyList<Metric>>> GetAllMetricsAsync()
        {
            return _api.GetAllMetricsAsync();
        }

        public Task<ResponseData<IReadOnlyList<Subscriber>>> GetAllSubscribersAsync()
        {
            return _api.GetAllSubscribersAsync();
        }

        public Task<ResponseData<IReadOnlyList<IncidentUpdate>>> GetAllUpdatesForIncidentAsync(int incidentId)
        {
            return _api.GetAllUpdatesForIncidentAsync(incidentId);
        }

        public Task<ResponseData<Component>> GetComponentAsync(int componentId)
        {
            return _api.GetComponentAsync(componentId);
        }

        public Task<ResponseData<ComponentGroup>> GetComponentGroupAsync(int groupId)
        {
            return _api.GetComponentGroupAsync(groupId);
        }

        public Task<ResponseData<Incident>> GetIncidentAsync(int incidentId)
        {
            return _api.GetIncidentAsync(incidentId);
        }

        public Task<ResponseData<IncidentUpdate>> GetIncidentUpdateAsync(int incidentId, int updateId)
        {
            return _api.GetIncidentUpdateAsync(incidentId, updateId);
        }

        public Task<ResponseData<Metric>> GetMetricAsync(int metricId)
        {
            return _api.GetMetricAsync(metricId);
        }

        public Task<ResponseData<IReadOnlyList<MetricPoint>>> GetMetricPointsAsync(int metricId)
        {
            return _api.GetMetricPointsAsync(metricId);
        }

        public Task<ResponseData<string>> PingAsync()
        {
            return _api.PingAsync();
        }

        public Task<ResponseData<Component>> UpdateComponentAsync(int componentId, PutComponent component)
        {
            return _api.UpdateComponentAsync(componentId, component);
        }

        public Task<ResponseData<ComponentGroup>> UpdateComponentGroupAsync(int groupId, PostComponentGroup group)
        {
            return _api.UpdateComponentGroupAsync(groupId, group);
        }

        public Task<ResponseData<Incident>> UpdateIncidentAsync(int incidentId, PutIncident incident)
        {
            return _api.UpdateIncidentAsync(incidentId, incident);
        }

        public Task<ResponseData<IncidentUpdate>> UpdateIncidentUpdateAsync(int incidentId, int updateId, IncidentStatus status, string message)
        {
            return _api.UpdateIncidentUpdateAsync(incidentId, updateId, status, message);
        }

        public Task<ResponseVersion> GetVersionAsync()
        {
            return _api.GetVersionAsync();
        }
    }
}