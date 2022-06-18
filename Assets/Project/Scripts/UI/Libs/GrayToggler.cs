using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	[ExecuteInEditMode]
	public class GrayToggler : Toggler
	{
		public Color colorDisabled = Color.gray;
		public Color colorEnabled = Color.white;
		public Material matDisabled;
		public Material matEnabled;

		public Image[] images;
		public Image[] imagesByColor;
		public Button[] buttons;

		public override void Apply()
		{
			base.Apply();
			if( !enabled ) {
				return;
			}
			Color color = _Toggle ? colorEnabled : colorDisabled;

			if( images != null ) {
				Material material = _Toggle ? matEnabled : matDisabled;
				for( int i=0; i<images.Length; i++ ) {
					if( images[i] != null ) images[i].material = material;
				}
			}
			if( imagesByColor != null ) {
				for( int i=0; i<imagesByColor.Length; i++ ) {
					if( imagesByColor[i] != null ) imagesByColor[i].color = color;
				}
			}
			if( buttons != null ) {
				for( int i=0; i<buttons.Length; i++ ) {
					if( buttons[i] != null ) buttons[i].interactable = _Toggle;
				}
			}
		}
	}
}