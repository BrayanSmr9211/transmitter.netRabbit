using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Domain.RabbitUser.Model
{
        public partial class QueueData
        {
            [JsonProperty("arguments")]
            public Arguments Arguments { get; set; }

            [JsonProperty("auto_delete")]
            public bool AutoDelete { get; set; }

            [JsonProperty("consumer_capacity")]
            public long ConsumerCapacity { get; set; }

            [JsonProperty("consumer_utilisation")]
            public long ConsumerUtilisation { get; set; }

            [JsonProperty("consumers")]
            public long Consumers { get; set; }

            [JsonProperty("durable")]
            public bool Durable { get; set; }

            [JsonProperty("effective_policy_definition")]
            public Arguments EffectivePolicyDefinition { get; set; }

            [JsonProperty("exclusive")]
            public bool Exclusive { get; set; }

            [JsonProperty("exclusive_consumer_tag")]
            public object ExclusiveConsumerTag { get; set; }

            [JsonProperty("garbage_collection")]
            public GarbageCollection GarbageCollection { get; set; }

            [JsonProperty("head_message_timestamp")]
            public object HeadMessageTimestamp { get; set; }

            [JsonProperty("idle_since")]
            public DateTimeOffset IdleSince { get; set; }

            [JsonProperty("memory")]
            public long Memory { get; set; }

            [JsonProperty("message_bytes")]
            public long MessageBytes { get; set; }

            [JsonProperty("message_bytes_paged_out")]
            public long MessageBytesPagedOut { get; set; }

            [JsonProperty("message_bytes_persistent")]
            public long MessageBytesPersistent { get; set; }

            [JsonProperty("message_bytes_ram")]
            public long MessageBytesRam { get; set; }

            [JsonProperty("message_bytes_ready")]
            public long MessageBytesReady { get; set; }

            [JsonProperty("message_bytes_unacknowledged")]
            public long MessageBytesUnacknowledged { get; set; }

            [JsonProperty("messages")]
            public long Messages { get; set; }

            [JsonProperty("messages_details")]
            public Details MessagesDetails { get; set; }

            [JsonProperty("messages_paged_out")]
            public long MessagesPagedOut { get; set; }

            [JsonProperty("messages_persistent")]
            public long MessagesPersistent { get; set; }

            [JsonProperty("messages_ram")]
            public long MessagesRam { get; set; }

            [JsonProperty("messages_ready")]
            public long MessagesReady { get; set; }

            [JsonProperty("messages_ready_details")]
            public Details MessagesReadyDetails { get; set; }

            [JsonProperty("messages_ready_ram")]
            public long MessagesReadyRam { get; set; }

            [JsonProperty("messages_unacknowledged")]
            public long MessagesUnacknowledged { get; set; }

            [JsonProperty("messages_unacknowledged_details")]
            public Details MessagesUnacknowledgedDetails { get; set; }

            [JsonProperty("messages_unacknowledged_ram")]
            public long MessagesUnacknowledgedRam { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("node")]
            public string Node { get; set; }

            [JsonProperty("operator_policy")]
            public object OperatorPolicy { get; set; }

            [JsonProperty("policy")]
            public object Policy { get; set; }

            [JsonProperty("recoverable_slaves")]
            public object RecoverableSlaves { get; set; }

            [JsonProperty("reductions")]
            public long Reductions { get; set; }

            [JsonProperty("reductions_details")]
            public Details ReductionsDetails { get; set; }

            [JsonProperty("single_active_consumer_tag")]
            public object SingleActiveConsumerTag { get; set; }

            [JsonProperty("state")]
            public string State { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("vhost")]
            public string Vhost { get; set; }
        }

        public partial class Arguments
        {
        }

        public partial class GarbageCollection
        {
            [JsonProperty("fullsweep_after")]
            public long FullsweepAfter { get; set; }

            [JsonProperty("max_heap_size")]
            public long MaxHeapSize { get; set; }

            [JsonProperty("min_bin_vheap_size")]
            public long MinBinVheapSize { get; set; }

            [JsonProperty("min_heap_size")]
            public long MinHeapSize { get; set; }

            [JsonProperty("minor_gcs")]
            public long MinorGcs { get; set; }
        }

        public partial class Details
        {
            [JsonProperty("rate")]
            public long Rate { get; set; }
        }
    }

