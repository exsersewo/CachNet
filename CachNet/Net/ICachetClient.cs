﻿using CachNet.Entities;
using RestEase;
using System;
using System.Threading.Tasks;

namespace CachNet.Net
{
    public interface ICachetClient : IDisposable
    {
        [Get("/ping")]
        public Task<ResponseSingle<string>> PingAsync();

        [Get("/version")]
        public Task<ResponseVersion> GetVersionAsync();

        #region Components

        [Get("/components")]
        public Task<ResponseComponent> GetAllComponentsAsync();

        [Get("/components/{componentId}")]
        public Task<ResponseComponent> GetComponentAsync([Path] int componentId);

        [Post("/components")]
        public Task<ResponseComponent> AddComponentAsync([Body] PostComponent component);

        [Put("/components/{componentId}")]
        public Task<ResponseComponent> UpdateComponentAsync([Path] int componentId, [Body] PutComponent component);

        [Delete("/components/{componentId}")]
        public Task DeleteComponentAsync([Path] int componentId);

        #endregion Components

        #region Component Groups

        [Get("/components/groups")]
        public Task<ResponseComponentGroup> GetAllComponentGroupsAsync();

        [Get("/components/groups/{groupId}")]
        public Task<ResponseComponentGroup> GetComponentGroupAsync([Path] int groupId);

        [Post("/components/groups")]
        public Task<ResponseComponentGroup> AddComponentGroupAsync([Body] PostComponentGroup group);

        [Put("/components/groups/{groupId}")]
        public Task<ResponseComponentGroup> UpdateComponentGroupAsync([Path] int groupId, [Body] PostComponentGroup group);

        [Delete("/components/groups/{groupId}")]
        public Task DeleteComponentGroupAsync([Path] int groupId);

        #endregion Component Groups

        #region Incidents

        [Get("/incidents")]
        public Task<ResponseIncident> GetAllIncidentsAsync();

        [Get("/incidents/{incidentId}")]
        public Task<ResponseIncident> GetIncidentAsync([Path] int incidentId);

        [Post("/incidents")]
        public Task<ResponseIncident> AddIncidentAsync([Body] PostIncident incidient);

        [Put("/incidents/{incidentId}")]
        public Task<ResponseIncident> UpdateIncidentAsync([Path] int incidentId, [Body] PutIncident incident);

        [Delete("/incidents/{incidentId}")]
        public Task DeleteIncidentAsync([Path] int incidentId);

        #endregion Incidents

        #region Incident Updates

        [Get("/incidents/{incidentId}/updates")]
        public Task<ResponseIncidentUpdate> GetAllUpdatesForIncidentAsync([Path] int incidentId);

        [Get("/incidents/{incidentId}/updates/{updateId}")]
        public Task<ResponseIncidentUpdate> GetIncidentUpdateAsync([Path] int incidentId, [Path] int updateId);

        [Post("/incidents/{incidentId}/updates")]
        public Task<ResponseIncidentUpdate> AddIncidentUpdateAsync([Path] int incidentId, [Body] PostIncidentUpdate update);

        [Put("/incidents/{incidentId}/updates/{updateId}")]
        public Task<ResponseIncidentUpdate> UpdateIncidentUpdateAsync([Path] int incidentId, [Path] int updateId, [Query] IncidentStatus status, [Query] string message);

        [Delete("/incidents/{incidentId}/updates/{updateId}")]
        public Task DeleteIncidentUpdateAsync([Path] int incidentId, [Path] int updateId);

        #endregion Incident Updates

        #region Metrics

        [Get("/metrics")]
        public Task<ResponseMetric> GetAllMetricsAsync();

        [Post("/metrics")]
        public Task<ResponseMetric> AddMetricAsync([Body] PostMetric metric);

        [Get("/metrics/{metricId}")]
        public Task<ResponseMetric> GetMetricAsync([Path] int metricId);

        [Delete("/metrics/{metricId}")]
        public Task DeleteMetricAsync([Path] int metricId);

        [Get("/metrics/{metricId}/points")]
        public Task<ResponseMetricPoint> GetMetricPointsAsync([Path] int metricId);

        [Post("/metrics/{metricId}/points")]
        public Task<ResponseMetricPoint> AddMetricPointAsync([Path] int metricId, [Body] PostMetricPoint metricPoint);

        [Delete("/metrics/{metricId}/points/{pointId}")]
        public Task DeleteMetricPointAsync([Path] int metricId, [Path] int pointId);

        #endregion Metrics

        #region Subscribers

        [Get("/subscribers")]
        public Task<ResponseSubscriber> GetAllSubscribersAsync();

        [Post("/subscribers")]
        public Task<ResponseSubscriber> AddSubscriberAsync([Body] PostSubscriber subscriber);

        [Delete("/subscribers/{subscriberId}")]
        public Task DeleteSubscriberAsync([Path] int subscriberId);

        #endregion Subscribers
    }
}