// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by the Game Data Editor.
//
//      Changes to this file will be lost if the code is regenerated.
//
//      This file was generated from this data file:
//      D:\projects\GDE_Unity_5.6.5_Dev\Assets\GameDataEditor\SampleScenes\GDEReadDataScene\Resources\read_scene_data.json
//  </autogenerated>
// ------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.Video;
using System;
using System.Collections.Generic;

using GameDataEditor;

namespace GameDataEditor
{
    public class GDEReadSceneUnityTypesData : IGDEData
    {
        static string go_fieldKey = "go_field";
		GameObject _go_field;
        public GameObject go_field
        {
            get { return _go_field; }
            set {
                if (_go_field != value)
                {
                    _go_field = value;
					GDEDataManager.SetUnityObject(_key, go_fieldKey, _go_field);
                }
            }
        }

        static string tex_fieldKey = "tex_field";
		Texture2D _tex_field;
        public Texture2D tex_field
        {
            get { return _tex_field; }
            set {
                if (_tex_field != value)
                {
                    _tex_field = value;
					GDEDataManager.SetUnityObject(_key, tex_fieldKey, _tex_field);
                }
            }
        }

        static string mat_fieldKey = "mat_field";
		Material _mat_field;
        public Material mat_field
        {
            get { return _mat_field; }
            set {
                if (_mat_field != value)
                {
                    _mat_field = value;
					GDEDataManager.SetUnityObject(_key, mat_fieldKey, _mat_field);
                }
            }
        }

        static string aud_fieldKey = "aud_field";
		AudioClip _aud_field;
        public AudioClip aud_field
        {
            get { return _aud_field; }
            set {
                if (_aud_field != value)
                {
                    _aud_field = value;
					GDEDataManager.SetUnityObject(_key, aud_fieldKey, _aud_field);
                }
            }
        }

        static string vid_fieldKey = "vid_field";
		VideoClip _vid_field;
        public VideoClip vid_field
        {
            get { return _vid_field; }
            set {
                if (_vid_field != value)
                {
                    _vid_field = value;
					GDEDataManager.SetUnityObject(_key, vid_fieldKey, _vid_field);
                }
            }
        }

        static string go_list_fieldKey = "go_list_field";
		public List<GameObject>      go_list_field;
		public void Set_go_list_field()
        {
	        GDEDataManager.SetUnityObjectList(_key, go_list_fieldKey, go_list_field);
		}
		

        public GDEReadSceneUnityTypesData(string key) : base(key)
        {
            GDEDataManager.RegisterItem(this.SchemaName(), key);
        }
        public override Dictionary<string, object> SaveToDict()
		{
			var dict = new Dictionary<string, object>();
			dict.Add(GDMConstants.SchemaKey, "ReadSceneUnityTypes");
			
            dict.Merge(true, go_field.ToGDEDict(go_fieldKey));
            dict.Merge(true, tex_field.ToGDEDict(tex_fieldKey));
            dict.Merge(true, mat_field.ToGDEDict(mat_fieldKey));
            dict.Merge(true, aud_field.ToGDEDict(aud_fieldKey));
            dict.Merge(true, vid_field.ToGDEDict(vid_fieldKey));

            dict.Merge(true, go_list_field.ToGDEDict(go_list_fieldKey));
            return dict;
		}

        public override void UpdateCustomItems(bool rebuildKeyList)
        {
        }

        public override void LoadFromDict(string dataKey, Dictionary<string, object> dict)
        {
            _key = dataKey;

			if (dict == null)
				LoadFromSavedData(dataKey);
			else
			{
                dict.TryGetGameObject(go_fieldKey, out _go_field);
                dict.TryGetTexture2D(tex_fieldKey, out _tex_field);
                dict.TryGetMaterial(mat_fieldKey, out _mat_field);
                dict.TryGetAudioClip(aud_fieldKey, out _aud_field);
                dict.TryGetVideoClip(vid_fieldKey, out _vid_field);

                dict.TryGetGameObjectList(go_list_fieldKey, out go_list_field);
                LoadFromSavedData(dataKey);
			}
		}

        public override void LoadFromSavedData(string dataKey)
		{
			_key = dataKey;
			
            _go_field = GDEDataManager.GetUnityObject(_key, go_fieldKey, _go_field);
            _tex_field = GDEDataManager.GetUnityObject(_key, tex_fieldKey, _tex_field);
            _mat_field = GDEDataManager.GetUnityObject(_key, mat_fieldKey, _mat_field);
            _aud_field = GDEDataManager.GetUnityObject(_key, aud_fieldKey, _aud_field);
            _vid_field = GDEDataManager.GetUnityObject(_key, vid_fieldKey, _vid_field);

            go_list_field = GDEDataManager.GetUnityObjectList(_key, go_list_fieldKey, go_list_field);
        }

        public GDEReadSceneUnityTypesData ShallowClone()
		{
			string newKey = Guid.NewGuid().ToString();
			GDEReadSceneUnityTypesData newClone = new GDEReadSceneUnityTypesData(newKey);


            Dictionary<string, object> dict;
			GDEDataManager.Get(_key, out dict);

            string path;
            dict.TryGetString(go_fieldKey, out path);
			GDEDataManager.SetString(newClone.Key, go_fieldKey, path);
            newClone.go_field = go_field;

            dict.TryGetString(tex_fieldKey, out path);
			GDEDataManager.SetString(newClone.Key, tex_fieldKey, path);
            newClone.tex_field = tex_field;

            dict.TryGetString(mat_fieldKey, out path);
			GDEDataManager.SetString(newClone.Key, mat_fieldKey, path);
            newClone.mat_field = mat_field;

            dict.TryGetString(aud_fieldKey, out path);
			GDEDataManager.SetString(newClone.Key, aud_fieldKey, path);
            newClone.aud_field = aud_field;

            dict.TryGetString(vid_fieldKey, out path);
			GDEDataManager.SetString(newClone.Key, vid_fieldKey, path);
            newClone.vid_field = vid_field;


            List<string> pathList;
            dict.TryGetStringList(go_list_fieldKey, out pathList);
			GDEDataManager.SetStringList(newClone.Key, go_list_fieldKey, pathList);
            newClone.go_list_field = new List<GameObject>(go_list_field);
			newClone.Set_go_list_field();

            return newClone;
		}

        public GDEReadSceneUnityTypesData DeepClone()
		{
			GDEReadSceneUnityTypesData newClone = ShallowClone();
            return newClone;
		}

        public void Reset_go_field()
        {
            GDEDataManager.ResetToDefault(_key, go_fieldKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetGameObject(go_fieldKey, out _go_field);
        }

        public void Reset_tex_field()
        {
            GDEDataManager.ResetToDefault(_key, tex_fieldKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetTexture2D(tex_fieldKey, out _tex_field);
        }

        public void Reset_mat_field()
        {
            GDEDataManager.ResetToDefault(_key, mat_fieldKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetMaterial(mat_fieldKey, out _mat_field);
        }

        public void Reset_aud_field()
        {
            GDEDataManager.ResetToDefault(_key, aud_fieldKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetAudioClip(aud_fieldKey, out _aud_field);
        }

        public void Reset_vid_field()
        {
            GDEDataManager.ResetToDefault(_key, vid_fieldKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetVideoClip(vid_fieldKey, out _vid_field);
        }

        public void Reset_go_list_field()
        {
	        GDEDataManager.ResetToDefault(_key, go_list_fieldKey);

	        Dictionary<string, object> dict;
	        GDEDataManager.Get(_key, out dict);
	        dict.TryGetGameObjectList(go_list_fieldKey, out go_list_field);
        }
		

        public void ResetAll()
        {
            GDEDataManager.ResetToDefault(_key, tex_fieldKey);
            GDEDataManager.ResetToDefault(_key, go_fieldKey);
            GDEDataManager.ResetToDefault(_key, mat_fieldKey);
            GDEDataManager.ResetToDefault(_key, go_list_fieldKey);
            GDEDataManager.ResetToDefault(_key, aud_fieldKey);
            GDEDataManager.ResetToDefault(_key, vid_fieldKey);


            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            LoadFromDict(_key, dict);
        }
    }
}
