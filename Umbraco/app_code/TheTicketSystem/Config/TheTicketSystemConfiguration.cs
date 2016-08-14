using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Umbraco.Core.Configuration
{
    // Represents the configuration file and it's attributes
    public class TheTicketSystemConfiguration : ConfigurationSection // root for the TheTicketSystem configurations
    {
        public static TheTicketSystemConfiguration GetConfig()
        {
            return ConfigurationManager.GetSection("TheTicketSystemConfiguration") as TheTicketSystemConfiguration;
        }

        // tells if the umbraco instance will be used as a server
        [ConfigurationProperty("isServer")]
        public IsServer isServer
        {
            get { return (IsServer)this["isServer"]; }
            set { this["isServer"] = value; }
        }

        // tells if the umbraco instance will be used as a client
        [ConfigurationProperty("isClient")]
        public IsClient isClient
        {
            get { return (IsClient)this["isClient"]; }
            set { this["isClient"] = value; }
        }

        // username for an connection to another server (only used when instance is a client)
        [ConfigurationProperty("username")]
        public Username username
        {
            get { return (Username)this["username"]; }
            set { this["username"] = value; }
        }

        // password for an connection to another server (only used when instance is a client)
        [ConfigurationProperty("password")]
        public Password password
        {
            get { return (Password)this["password"]; }
            set { this["password"] = value; }
        }

        // server url (only used when instance is a client)
        [ConfigurationProperty("serverUrl")]
        public ServerUrl serverUrl
        {
            get { return (ServerUrl)this["serverUrl"]; }
            set { this["serverUrl"] = value; }
        }
    }

    // represents the isServer attribute
    public class IsServer : ConfigurationElement
    {
        [ConfigurationProperty("value", DefaultValue = "true", IsRequired = true)]
        public string Value
        {
            get { return this["value"] as string; }
            set { this["value"] = value; }
        }
    }

    // represents the isClient attribute
    public class IsClient : ConfigurationElement
    {
        [ConfigurationProperty("value", DefaultValue = "true", IsRequired = true)]
        public string Value {
            get { return this["value"] as string; }
            set { this["value"] = value; }
        }
    }

    // represents the username attribute
    public class Username : ConfigurationElement
    {
        [ConfigurationProperty("value")]
        public string Value
        {
            get { return this["value"] as string; }
            set { this["value"] = value; }
        }
    }

    // represents the password attribute
    public class Password : ConfigurationElement
    {
        [ConfigurationProperty("value")]
        public string Value
        {
            get { return this["value"] as string; }
            set { this["value"] = value; }
        }
    }

    // represents the serverUrl attribute
    public class ServerUrl : ConfigurationElement
    {
        [ConfigurationProperty("value")]
        public string Value
        {
            get { return this["value"] as string; }
            set { this["value"] = value; }
        }
    }
}