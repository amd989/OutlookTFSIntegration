// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingStorage.cs" company="">
//   
// </copyright>
// <summary>
//   The setting storage.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TFSIntegration.Classes
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.Server;

    /// <summary>The setting storage.</summary>
    public class SettingStorage
    {
        #region Fields

        /// <summary>The selected team project.</summary>
        private const string SelectedTeamProjectKey = "ProjectInfo";

        /// <summary>The TFS team project collection.</summary>
        private const string TfsTeamProjectCollectionKey = "TfsTeamProjectCollection";

        #endregion

        #region Public Properties

        /// <summary>Gets or sets the selected team project.</summary>
        public ProjectInfo SelectedTeamProject
        {
            get
            {
                return this.Retrieve<ProjectInfo>(SelectedTeamProjectKey);
            }

            set
            {
                this.Store(value, SelectedTeamProjectKey);
            }
        }

        /// <summary>Gets or sets the TFS team project collection.</summary>
        public string TfsTeamProjectCollectionUri
        {
            get
            {
                return this.Retrieve<string>(TfsTeamProjectCollectionKey);
            }

            set
            {
                this.Store(value, TfsTeamProjectCollectionKey);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>The retrieve.</summary>
        /// <param name="name">The name.</param>
        /// <typeparam name="T">The type</typeparam>
        /// <returns>The <see cref="T"/>.</returns>
        public T Retrieve<T>(string name) where T : class
        {
            var fileManager = new FileManager();
            string item = fileManager.ReadFile(string.Format("./{0}.stg", name));
            if (!string.IsNullOrEmpty(item))
            {
                var deserializedClass = this.DeserializeFromXml<T>(item);
                return deserializedClass;
            }
            return null;
        }

        /// <summary>The store.</summary>
        /// <param name="item">The item.</param>
        /// <param name="name">The name.</param>
        /// <typeparam name="T">The type</typeparam>
        public void Store<T>(T item, string name)
        {
            var fileManager = new FileManager();
            string serializedClass = this.SerializeToXml(item);
            fileManager.WriteFile(string.Format("./{0}.stg", name), serializedClass);
        }

        #endregion

        #region Methods

        /// <summary>The deserialize from xml.</summary>
        /// <param name="xmlClass">The xml Class.</param>
        /// <typeparam name="T">The type of the object</typeparam>
        /// <returns>The <see cref="T"/>.</returns>
        private T DeserializeFromXml<T>(string xmlClass) where T : class
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            var stringReader = new StringReader(xmlClass);
            XmlReader xmlWriter = XmlReader.Create(stringReader);
            var newObject = xmlSerializer.Deserialize(xmlWriter) as T;
            return newObject;
        }

        /// <summary>The serialize to xml.</summary>
        /// <param name="store">The store.</param>
        /// <typeparam name="T">The type of the item to serialize</typeparam>
        /// <returns>The <see cref="string"/>.</returns>
        private string SerializeToXml<T>(T store)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            var stringWriter = new StringWriter();
            XmlWriter xmlWriter = XmlWriter.Create(stringWriter);
            xmlSerializer.Serialize(xmlWriter, store);
            string xml = stringWriter.ToString(); // Your xml
            return xml;
        }

        #endregion
    }
}