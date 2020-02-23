using CachNet.Entities;
using RestEase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CachNet.Net
{
    public interface ICachetClient : IDisposable
    {
        [Get("/ping")]
        public Task<ResponseData<string>> PingAsync();

        [Get("/version")]
        public Task<ResponseVersion> GetVersionAsync();

        #region Components

        [Get("/components")]
        public Task<ResponseData<IReadOnlyList<Component>>> GetAllComponentsAsync();

        [Get("/components/{componentId}")]
        public Task<ResponseData<Component>> GetComponentAsync([Path] int componentId);

        [Post("/components")]
        public Task<ResponseData<Component>> AddComponentAsync([Body] PostComponent component);

        [Put("/components/{componentId}")]
        public Task<ResponseData<Component>> UpdateComponentAsync([Path] int componentId, [Body] PutComponent component);

        [Delete("/components/{componentId}")]
        public Task DeleteComponentAsync([Path] int componentId);

        #endregion Components

        #region Component Groups

        [Get("/components/groups")]
        public Task<ResponseData<IReadOnlyList<ComponentGroup>>> GetAllComponentGroupsAsync();

        [Get("/components/groups/{groupId}")]
        public Task<ResponseData<ComponentGroup>> GetComponentGroupAsync([Path] int groupId);

        [Post("/components/groups")]
        public Task<ResponseData<ComponentGroup>> AddComponentGroupAsync([Body] PostComponentGroup group);

        [Put("/components/groups/{groupId}")]
        public Task<ResponseData<ComponentGroup>> UpdateComponentGroupAsync([Path] int groupId, [Body] PostComponentGroup group);

        [Delete("/components/groups/{groupId}")]
        public Task DeleteComponentGroupAsync([Path] int groupId);

        #endregion Component Groups

        #region Incidents

        [Get("/incidents")]
        public Task<ResponseData<IReadOnlyList<Incident>>> GetAllIncidentsAsync();

        [Get("/incidents/{incidentId}")]
        public Task<ResponseData<Incident>> GetIncidentAsync([Path] int incidentId);

        [Post("/incidents")]
        public Task<ResponseData<Incident>> AddIncidentAsync([Body] PostIncident incidient);

        [Put("/incidents/{incidentId}")]
        public Task<ResponseData<Incident>> UpdateIncidentAsync([Path] int incidentId, [Body] PutIncident incident);

        [Delete("/incidents/{incidentId}")]
        public Task DeleteIncidentAsync([Path] int incidentId);

        #endregion Incidents

        #region Incident Updates

        [Get("/incidents/{incidentId}/updates")]
        public Task<ResponseData<IReadOnlyList<IncidentUpdate>>> GetAllUpdatesForIncidentAsync([Path] int incidentId);

        [Get("/incidents/{incidentId}/updates/{updateId}")]
        public Task<ResponseData<IncidentUpdate>> GetIncidentUpdateAsync([Path] int incidentId, [Path] int updateId);

        [Post("/incidents/{incidentId}/updates")]
        public Task<ResponseData<IncidentUpdate>> AddIncidentUpdateAsync([Path] int incidentId, [Body] PostIncidentUpdate update);

        [Put("/incidents/{incidentId}/updates/{updateId}")]
        public Task<ResponseData<IncidentUpdate>> UpdateIncidentUpdateAsync([Path] int incidentId, [Path] int updateId, [Query] IncidentStatus status, [Query] string message);

        [Delete("/incidents/{incidentId}/updates/{updateId}")]
        public Task DeleteIncidentUpdateAsync([Path] int incidentId, [Path] int updateId);

        #endregion Incident Updates

        #region Metrics

        [Get("/metrics")]
        public Task<ResponseData<IReadOnlyList<Metric>>> GetAllMetricsAsync();

        [Post("/metrics")]
        public Task<ResponseData<Metric>> AddMetricAsync([Body] PostMetric metric);

        [Get("/metrics/{metricId}")]
        public Task<ResponseData<Metric>> GetMetricAsync([Path] int metricId);

        [Delete("/metrics/{metricId}")]
        public Task DeleteMetricAsync([Path] int metricId);

        [Get("/metrics/{metricId}/points")]
        public Task<ResponseData<IReadOnlyList<MetricPoint>>> GetMetricPointsAsync([Path] int metricId);

        [Post("/metrics/{metricId}/points")]
        public Task<ResponseData<IReadOnlyList<MetricPoint>>> AddMetricPointAsync([Path] int metricId, [Body] PostMetricPoint metricPoint);

        [Delete("/metrics/{metricId}/points/{pointId}")]
        public Task DeleteMetricPointAsync([Path] int metricId, [Path] int pointId);

        #endregion Metrics

        #region Subscribers

        [Get("/subscribers")]
        public Task<ResponseData<IReadOnlyList<Subscriber>>> GetAllSubscribersAsync();

        [Post("/subscribers")]
        public Task<ResponseData<Subscriber>> AddSubscriberAsync([Body] PostSubscriber subscriber);

        [Delete("/subscribers/{subscriberId}")]
        public Task DeleteSubscriberAsync([Path] int subscriberId);

        #endregion Subscribers
    }
}