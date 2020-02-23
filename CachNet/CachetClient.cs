using CachNet.Entities;
using CachNet.Net;
using Newtonsoft.Json;
using RestEase;
using System;
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

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            _api = new RestClient(httpClient)
            {
                JsonSerializerSettings = settings
            }.For<ICachetClient>();
        }

        public string BaseUrl { get; private set; }

        public void Dispose() => _api.Dispose();

        public Task<ResponseComponent> AddComponentAsync(PostComponent component)
        {
            return _api.AddComponentAsync(component);
        }

        public Task<ResponseComponentGroup> AddComponentGroupAsync(PostComponentGroup group)
        {
            return _api.AddComponentGroupAsync(group);
        }

        public Task<ResponseIncidentUpdate> AddIncidentUpdateAsync(int incidentId, PostIncidentUpdate update)
        {
            return _api.AddIncidentUpdateAsync(incidentId, update);
        }

        public Task<ResponseIncident> AddIncidentAsync(PostIncident incidient)
        {
            return _api.AddIncidentAsync(incidient);
        }

        public Task<ResponseMetric> AddMetricAsync(PostMetric metric)
        {
            return _api.AddMetricAsync(metric);
        }

        public Task<ResponseMetricPoint> AddMetricPointAsync(int metricId, PostMetricPoint metricPoint)
        {
            return _api.AddMetricPointAsync(metricId, metricPoint);
        }

        public Task<ResponseSubscriber> AddSubscriberAsync(PostSubscriber subscriber)
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

        public Task<ResponseComponentGroup> GetAllComponentGroupsAsync()
        {
            return _api.GetAllComponentGroupsAsync();
        }

        public Task<ResponseComponent> GetAllComponentsAsync()
        {
            return _api.GetAllComponentsAsync();
        }

        public Task<ResponseIncident> GetAllIncidentsAsync()
        {
            return _api.GetAllIncidentsAsync();
        }

        public Task<ResponseMetric> GetAllMetricsAsync()
        {
            return _api.GetAllMetricsAsync();
        }

        public Task<ResponseSubscriber> GetAllSubscribersAsync()
        {
            return _api.GetAllSubscribersAsync();
        }

        public Task<ResponseIncidentUpdate> GetAllUpdatesForIncidentAsync(int incidentId)
        {
            return _api.GetAllUpdatesForIncidentAsync(incidentId);
        }

        public Task<ResponseComponent> GetComponentAsync(int componentId)
        {
            return _api.GetComponentAsync(componentId);
        }

        public Task<ResponseComponentGroup> GetComponentGroupAsync(int groupId)
        {
            return _api.GetComponentGroupAsync(groupId);
        }

        public Task<ResponseIncident> GetIncidentAsync(int incidentId)
        {
            return _api.GetIncidentAsync(incidentId);
        }

        public Task<ResponseIncidentUpdate> GetIncidentUpdateAsync(int incidentId, int updateId)
        {
            return _api.GetIncidentUpdateAsync(incidentId, updateId);
        }

        public Task<ResponseMetric> GetMetricAsync(int metricId)
        {
            return _api.GetMetricAsync(metricId);
        }

        public Task<ResponseMetricPoint> GetMetricPointsAsync(int metricId)
        {
            return _api.GetMetricPointsAsync(metricId);
        }

        public Task<ResponseSingle<string>> PingAsync()
        {
            return _api.PingAsync();
        }

        public Task<ResponseComponent> UpdateComponentAsync(int componentId, PutComponent component)
        {
            return _api.UpdateComponentAsync(componentId, component);
        }

        public Task<ResponseComponentGroup> UpdateComponentGroupAsync(int groupId, PostComponentGroup group)
        {
            return _api.UpdateComponentGroupAsync(groupId, group);
        }

        public Task<ResponseIncident> UpdateIncidentAsync(int incidentId, PutIncident incident)
        {
            return _api.UpdateIncidentAsync(incidentId, incident);
        }

        public Task<ResponseIncidentUpdate> UpdateIncidentUpdateAsync(int incidentId, int updateId, IncidentStatus status, string message)
        {
            return _api.UpdateIncidentUpdateAsync(incidentId, updateId, status, message);
        }

        public Task<ResponseVersion> GetVersionAsync()
        {
            return _api.GetVersionAsync();
        }
    }
}