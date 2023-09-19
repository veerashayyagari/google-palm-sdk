// Copyright 2023 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// Generated code. DO NOT EDIT!

#pragma warning disable CS8981
using gagv = Google.Ai.Generativelanguage.V1Beta2;
using gaxgrpc = Google.Api.Gax.Grpc;
using gpr = Google.Protobuf.Reflection;
using sys = System;
using scg = System.Collections.Generic;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>Static class to provide extension methods to configure API clients.</summary>
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>Adds a singleton <see cref="gagv::DiscussServiceClient"/> to <paramref name="services"/>.</summary>
        /// <param name="services">
        /// The service collection to add the client to. The services are used to configure the client when requested.
        /// </param>
        /// <param name="action">
        /// An optional action to invoke on the client builder. This is invoked before services from
        /// <paramref name="services"/> are used.
        /// </param>
        public static IServiceCollection AddDiscussServiceClient(this IServiceCollection services, sys::Action<gagv::DiscussServiceClientBuilder> action = null) =>
            services.AddSingleton(provider =>
            {
                gagv::DiscussServiceClientBuilder builder = new gagv::DiscussServiceClientBuilder();
                action?.Invoke(builder);
                return builder.Build(provider);
            });

        /// <summary>Adds a singleton <see cref="gagv::ModelServiceClient"/> to <paramref name="services"/>.</summary>
        /// <param name="services">
        /// The service collection to add the client to. The services are used to configure the client when requested.
        /// </param>
        /// <param name="action">
        /// An optional action to invoke on the client builder. This is invoked before services from
        /// <paramref name="services"/> are used.
        /// </param>
        public static IServiceCollection AddModelServiceClient(this IServiceCollection services, sys::Action<gagv::ModelServiceClientBuilder> action = null) =>
            services.AddSingleton(provider =>
            {
                gagv::ModelServiceClientBuilder builder = new gagv::ModelServiceClientBuilder();
                action?.Invoke(builder);
                return builder.Build(provider);
            });

        /// <summary>Adds a singleton <see cref="gagv::TextServiceClient"/> to <paramref name="services"/>.</summary>
        /// <param name="services">
        /// The service collection to add the client to. The services are used to configure the client when requested.
        /// </param>
        /// <param name="action">
        /// An optional action to invoke on the client builder. This is invoked before services from
        /// <paramref name="services"/> are used.
        /// </param>
        public static IServiceCollection AddTextServiceClient(this IServiceCollection services, sys::Action<gagv::TextServiceClientBuilder> action = null) =>
            services.AddSingleton(provider =>
            {
                gagv::TextServiceClientBuilder builder = new gagv::TextServiceClientBuilder();
                action?.Invoke(builder);
                return builder.Build(provider);
            });
    }
}
