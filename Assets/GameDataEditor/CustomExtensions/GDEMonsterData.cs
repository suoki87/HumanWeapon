// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by the Game Data Editor.
//
//      Changes to this file will be lost if the code is regenerated.
//
//      This file was generated from this data file:
//      C:\Users\esock\OneDrive\문서\HumanWeapon\Assets/GameDataEditor/Resources/gde_data.txt
//  </autogenerated>
// ------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.Video;
using System;
using System.Linq;
using System.Collections.Generic;

using GameDataEditor;

namespace GameDataEditor
{
    public class GDEMonsterData : IGDEData
    {
        static string noKey = "no";
		int _no;
        public int no
        {
            get { return _no; }
            set {
                if (_no != value)
                {
                    _no = value;
					GDEDataManager.SetInt(_key, noKey, _no);
                }
            }
        }

        static string indexKey = "index";
		int _index;
        public int index
        {
            get { return _index; }
            set {
                if (_index != value)
                {
                    _index = value;
					GDEDataManager.SetInt(_key, indexKey, _index);
                }
            }
        }

        static string atkKey = "atk";
		float _atk;
        public float atk
        {
            get { return _atk; }
            set {
                if (_atk != value)
                {
                    _atk = value;
					GDEDataManager.SetFloat(_key, atkKey, _atk);
                }
            }
        }

        static string defKey = "def";
		float _def;
        public float def
        {
            get { return _def; }
            set {
                if (_def != value)
                {
                    _def = value;
					GDEDataManager.SetFloat(_key, defKey, _def);
                }
            }
        }

        static string hpKey = "hp";
		float _hp;
        public float hp
        {
            get { return _hp; }
            set {
                if (_hp != value)
                {
                    _hp = value;
					GDEDataManager.SetFloat(_key, hpKey, _hp);
                }
            }
        }

        static string movKey = "mov";
		float _mov;
        public float mov
        {
            get { return _mov; }
            set {
                if (_mov != value)
                {
                    _mov = value;
					GDEDataManager.SetFloat(_key, movKey, _mov);
                }
            }
        }

        static string critKey = "crit";
		float _crit;
        public float crit
        {
            get { return _crit; }
            set {
                if (_crit != value)
                {
                    _crit = value;
					GDEDataManager.SetFloat(_key, critKey, _crit);
                }
            }
        }

        static string critDmgKey = "critDmg";
		float _critDmg;
        public float critDmg
        {
            get { return _critDmg; }
            set {
                if (_critDmg != value)
                {
                    _critDmg = value;
					GDEDataManager.SetFloat(_key, critDmgKey, _critDmg);
                }
            }
        }

        static string toughnessKey = "toughness";
		float _toughness;
        public float toughness
        {
            get { return _toughness; }
            set {
                if (_toughness != value)
                {
                    _toughness = value;
					GDEDataManager.SetFloat(_key, toughnessKey, _toughness);
                }
            }
        }

        static string nameKey = "name";
		string _name;
        public string name
        {
            get { return _name; }
            set {
                if (_name != value)
                {
                    _name = value;
					GDEDataManager.SetString(_key, nameKey, _name);
                }
            }
        }

        public GDEMonsterData(string key) : base(key)
        {
            GDEDataManager.RegisterItem(this.SchemaName(), key);
        }
        public override Dictionary<string, object> SaveToDict()
		{
			var dict = new Dictionary<string, object>();
			dict.Add(GDMConstants.SchemaKey, "Monster");
			
            dict.Merge(true, no.ToGDEDict(noKey));
            dict.Merge(true, index.ToGDEDict(indexKey));
            dict.Merge(true, atk.ToGDEDict(atkKey));
            dict.Merge(true, def.ToGDEDict(defKey));
            dict.Merge(true, hp.ToGDEDict(hpKey));
            dict.Merge(true, mov.ToGDEDict(movKey));
            dict.Merge(true, crit.ToGDEDict(critKey));
            dict.Merge(true, critDmg.ToGDEDict(critDmgKey));
            dict.Merge(true, toughness.ToGDEDict(toughnessKey));
            dict.Merge(true, name.ToGDEDict(nameKey));
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
                dict.TryGetInt(noKey, out _no);
                dict.TryGetInt(indexKey, out _index);
                dict.TryGetFloat(atkKey, out _atk);
                dict.TryGetFloat(defKey, out _def);
                dict.TryGetFloat(hpKey, out _hp);
                dict.TryGetFloat(movKey, out _mov);
                dict.TryGetFloat(critKey, out _crit);
                dict.TryGetFloat(critDmgKey, out _critDmg);
                dict.TryGetFloat(toughnessKey, out _toughness);
                dict.TryGetString(nameKey, out _name);
                LoadFromSavedData(dataKey);
			}
		}

        public override void LoadFromSavedData(string dataKey)
		{
			_key = dataKey;
			
            _no = GDEDataManager.GetInt(_key, noKey, _no);
            _index = GDEDataManager.GetInt(_key, indexKey, _index);
            _atk = GDEDataManager.GetFloat(_key, atkKey, _atk);
            _def = GDEDataManager.GetFloat(_key, defKey, _def);
            _hp = GDEDataManager.GetFloat(_key, hpKey, _hp);
            _mov = GDEDataManager.GetFloat(_key, movKey, _mov);
            _crit = GDEDataManager.GetFloat(_key, critKey, _crit);
            _critDmg = GDEDataManager.GetFloat(_key, critDmgKey, _critDmg);
            _toughness = GDEDataManager.GetFloat(_key, toughnessKey, _toughness);
            _name = GDEDataManager.GetString(_key, nameKey, _name);
        }

        public GDEMonsterData ShallowClone()
		{
			string newKey = Guid.NewGuid().ToString();
			GDEMonsterData newClone = new GDEMonsterData(newKey);

            newClone.no = no;
            newClone.index = index;
            newClone.atk = atk;
            newClone.def = def;
            newClone.hp = hp;
            newClone.mov = mov;
            newClone.crit = crit;
            newClone.critDmg = critDmg;
            newClone.toughness = toughness;
            newClone.name = name;

            return newClone;
		}

        public GDEMonsterData DeepClone()
		{
			GDEMonsterData newClone = ShallowClone();
            return newClone;
		}

        public void Reset_no()
        {
            GDEDataManager.ResetToDefault(_key, noKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetInt(noKey, out _no);
        }

        public void Reset_index()
        {
            GDEDataManager.ResetToDefault(_key, indexKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetInt(indexKey, out _index);
        }

        public void Reset_atk()
        {
            GDEDataManager.ResetToDefault(_key, atkKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetFloat(atkKey, out _atk);
        }

        public void Reset_def()
        {
            GDEDataManager.ResetToDefault(_key, defKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetFloat(defKey, out _def);
        }

        public void Reset_hp()
        {
            GDEDataManager.ResetToDefault(_key, hpKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetFloat(hpKey, out _hp);
        }

        public void Reset_mov()
        {
            GDEDataManager.ResetToDefault(_key, movKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetFloat(movKey, out _mov);
        }

        public void Reset_crit()
        {
            GDEDataManager.ResetToDefault(_key, critKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetFloat(critKey, out _crit);
        }

        public void Reset_critDmg()
        {
            GDEDataManager.ResetToDefault(_key, critDmgKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetFloat(critDmgKey, out _critDmg);
        }

        public void Reset_toughness()
        {
            GDEDataManager.ResetToDefault(_key, toughnessKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetFloat(toughnessKey, out _toughness);
        }

        public void Reset_name()
        {
            GDEDataManager.ResetToDefault(_key, nameKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetString(nameKey, out _name);
        }

        public void ResetAll()
        {
             #if !UNITY_WEBPLAYER
             GDEDataManager.DeregisterItem(this.SchemaName(), _key);
             #else

            GDEDataManager.ResetToDefault(_key, noKey);
            GDEDataManager.ResetToDefault(_key, indexKey);
            GDEDataManager.ResetToDefault(_key, nameKey);
            GDEDataManager.ResetToDefault(_key, atkKey);
            GDEDataManager.ResetToDefault(_key, defKey);
            GDEDataManager.ResetToDefault(_key, hpKey);
            GDEDataManager.ResetToDefault(_key, movKey);
            GDEDataManager.ResetToDefault(_key, critKey);
            GDEDataManager.ResetToDefault(_key, critDmgKey);
            GDEDataManager.ResetToDefault(_key, toughnessKey);


            #endif

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            LoadFromDict(_key, dict);
        }
    }
}
