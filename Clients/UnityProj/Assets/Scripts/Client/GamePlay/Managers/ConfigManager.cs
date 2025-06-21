using System.Collections.Generic;
using System.IO;
using System.Linq;
using BiangLibrary;
using BiangLibrary.Singleton;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

#endif

public class ConfigManager : TSingletonBaseManager<ConfigManager>
{
}