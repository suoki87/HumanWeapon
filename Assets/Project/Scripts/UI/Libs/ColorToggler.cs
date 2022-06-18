using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UI
{
	[ExecuteInEditMode]
	public class ColorToggler : Toggler
	{
		public Color colorDisabled = Color.gray;
		public Color colorEnabled = Color.white;

		public Image[] images;

		public override void Apply()
		{
			base.Apply();

			Color color = _Toggle ? colorEnabled : colorDisabled;

			if ( images != null ) {
				for ( int i = 0; i < images.Length; i++ ) {
					if ( images[i] != null ) images[i].color = color;
				}
			}
		}
	}
}