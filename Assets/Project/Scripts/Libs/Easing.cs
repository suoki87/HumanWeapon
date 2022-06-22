using UnityEngine;
using System;

namespace PlayCore
{
    public enum EaseType
    {
        Linear,
        InQuad,
        OutQuad,
        InOutQuad,
        InQuart,
        OutQuart,
        InOutQuart,
        InQuint,
        OutQuint,
        InOutQuint,
        InCubic,
        OutCubic,
        InOutCubic,
        InExpo,
        OutExpo,
        InOutExpo,
        InCirc,
        OutCirc,
        InOutCirc,
        InSine,
        OutSine,
        InOutSine,
        InElastic,
        OutElastic,
        InOutElastic,
        InBounce,
        OutBounce,
        InOutBounce,
        InBack,
        OutBack,
        InOutBack
    }

    ///----------------------------------------------------------------------------------------------

    ///Easing functions to be used for interpolation
    public static class Easing
    {
        private static Func<float, float, float, float>[] EaseFunctions = new Func<float, float, float, float>[] {
        Linear,
        InQuad,
        OutQuad,
        InOutQuad,
        InQuart,
        OutQuart,
        InOutQuart,
        InQuint,
        OutQuint,
        InOutQuint,
        InCubic,
        OutCubic,
        InOutCubic,
        InExpo,
        OutExpo,
        InOutExpo,
        InCirc,
        OutCirc,
        InOutCirc,
        InSinue,
        OutSine,
        InOutSine,
        InElastic,
        OutElastic,
        InOutElastic,
        InBounce,
        OutBounce,
        InOutBounce,
        InBack,
        OutBack,
        InOutBack

    };

        ///----------------------------------------------------------------------------------------------

        public static float Ease(EaseType type, float from, float to, float t) {
            if ( t <= 0 ) { return from; }
            if ( t >= 1 ) { return to; }
            return Function(type)(from, to, t);
        }

        public static Vector3 Ease(EaseType type, Vector3 from, Vector3 to, float t) {
            if ( t <= 0 ) { return from; }
            if ( t >= 1 ) { return to; }
            return Vector3.LerpUnclamped(from, to, Function(type)(0, 1, t));
        }

        public static Quaternion Ease(EaseType type, Quaternion from, Quaternion to, float t) {
            if ( t <= 0 ) { return from; }
            if ( t >= 1 ) { return to; }
            return Quaternion.LerpUnclamped(from, to, Function(type)(0, 1, t));
        }

        public static Color Ease(EaseType type, Color from, Color to, float t) {
            if ( t <= 0 ) { return from; }
            if ( t >= 1 ) { return to; }
            return Color.LerpUnclamped(from, to, Function(type)(0, 1, t));
        }

        public static Vector3 Bezier(EaseType type, Vector3 a, Vector3 b, Vector3 c, float t )
        {
            t = Function(type)(0, 1f, t);
            var omt = 1f - t;
            return a * omt * omt + 2f * b * omt * t + c * t * t;
        }


        public static float Ease(AnimationCurve curve, float from, float to, float t) {
            if ( t <= 0 ) { return from; }
            if ( t >= 1 ) { return to; }
            return curve.Evaluate( t );
        }

        public static Vector3 Ease( AnimationCurve curve, Vector3 from, Vector3 to, float t )
        {
            if ( t <= 0 ) { return from; }
            if ( t >= 1 ) { return to; }
            return Vector3.LerpUnclamped(from, to, curve.Evaluate( t ));
        }

        public static Quaternion Ease(AnimationCurve curve, Quaternion from, Quaternion to, float t) {
            if ( t <= 0 ) { return from; }
            if ( t >= 1 ) { return to; }
            return Quaternion.LerpUnclamped(from, to, curve.Evaluate(t));
        }

        public static Color Ease(AnimationCurve curve, Color from, Color to, float t) {
            if ( t <= 0 ) { return from; }
            if ( t >= 1 ) { return to; }
            return Color.LerpUnclamped(from, to, curve.Evaluate( t ));
        }


        public static Vector3 Bezier(AnimationCurve curve, Vector3 a, Vector3 b, Vector3 c, float t )
        {
            t = curve.Evaluate( t );
            var omt = 1f - t;
            return a * omt * omt + 2f * b * omt * t + c * t * t;
        }

        public static float Difference(this float f, float a, float b) {
            if ( a > b ) return -Mathf.Abs(a - b);
            return Mathf.Abs(a - b);
        }


        public static float Linear(float from, float to, float t) {
            return Mathf.Lerp(from, to, t);
        }

        public static float InQuad(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            return from + value * t * t;
        }

        public static float OutQuad(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            return from + value * t * ( 2f - t );
        }

        public static float InOutQuad(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            float value2;
            if ( ( t *= 2f ) < 1f )
                value2 = 0.5f * t * t;
            else
                value2 = -0.5f * ( --t * ( t - 2f ) - 1f );
            return from + value * value2;
        }

        public static float InQuart(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            return from + value * t * t * t * t;
        }

        public static float OutQuart(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            float value2 = 1f - ( --t * t * t * t );
            return from + value * value2;
        }

        public static float InOutQuart(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            if ( ( t *= 2f ) < 1f )
                return from + value * 0.5f * t * t * t * t;
            return from + value * -0.5f * ( ( t -= 2f ) * t * t * t - 2f );
        }

        public static float InQuint(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            return from + value * t * t * t * t * t;
        }

        public static float OutQuint(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            float value2 = --t * t * t * t * t + 1f;
            return from + value * value2;
        }

        public static float InOutQuint(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            if ( ( t *= 2f ) < 1 )
                return from + value * 0.5f * t * t * t * t * t;
            return from + value * 0.5f * ( ( t -= 2f ) * t * t * t * t + 2f );
        }

        public static float InCubic(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            return from + value * t * t * t;
        }

        public static float OutCubic(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            float value2 = --t * t * t + 1f;
            return from + value * value2;
        }

        public static float InOutCubic(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to) * 0.5f;
            float value2;
            if ( ( t *= 2f ) < 1f )
                value2 = t * t * t;
            else value2 = ( ( t -= 2f ) * t * t + 2f );
            return from + value * value2;
        }

        public static float InSinue(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            float value2 = 1f - Mathf.Cos(t * Mathf.PI / 2f);
            return from + value * value2;
        }

        public static float OutSine(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            float value2 = Mathf.Sin(t * Mathf.PI / 2f);
            return from + value * value2;
        }

        public static float InOutSine(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            float value2 = 0.5f * ( 1f - Mathf.Cos(Mathf.PI * t) );
            return from + value * value2;
        }

        public static float InExpo(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            float value2 = Mathf.Approximately(0f, t) ? 0f : Mathf.Pow(1024f, t - 1f);
            return from + value * value2;
        }

        public static float OutExpo(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            float value2 = Mathf.Approximately(1f, t) ? 1f : 1f - Mathf.Pow(2f, -10f * t);
            return from + value * value2;
        }

        public static float InOutExpo(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            if ( Mathf.Approximately(0f, t) )
                return from;
            if ( Mathf.Approximately(1f, t) )
                return from + value;
            if ( ( t *= 2f ) < 1f )
                return from + value * 0.5f * Mathf.Pow(1024f, t - 1f);
            return from + value * 0.5f * ( -Mathf.Pow(2f, -10f * ( t - 1f )) + 2f );
        }

        public static float InCirc(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            float value2 = 1f - Mathf.Sqrt(1f - t * t);
            return from + value * value2;
        }

        public static float OutCirc(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            return from + value * Mathf.Sqrt(1f - ( --t * t ));
        }

        public static float InOutCirc(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            if ( ( t *= 2f ) < 1f )
                return from + value * -0.5f * ( Mathf.Sqrt(1f - t * t) - 1f );
            return from + value * 0.5f * ( Mathf.Sqrt(1f - ( t -= 2f ) * t) + 1f );
        }

        public static float InElastic(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            float s, a = 0.1f, p = 0.4f;
            if ( Mathf.Approximately(0, t) )
                return from;
            if ( Mathf.Approximately(1f, t) )
                return from + value;
            if ( a < 1f ) {
                a = 1f;
                s = p / 4f;
            } else
                s = p * Mathf.Asin(1f / a) / ( 2f * Mathf.PI );
            return from + value * -( a * Mathf.Pow(2f, 10f * ( t -= 1f )) * Mathf.Sin(( t - s ) * ( 2f * Mathf.PI ) / p) );
        }

        public static float OutElastic(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            float s, a = 0.1f, p = 0.4f;
            if ( Mathf.Approximately(0, t) )
                return from;
            if ( Mathf.Approximately(1f, t) )
                return from + value;
            if ( a < 1f ) {
                a = 1f;
                s = p / 4f;
            } else
                s = p * Mathf.Asin(1f / a) / ( 2f * Mathf.PI );
            return from + value * ( a * Mathf.Pow(2f, -10f * t) * Mathf.Sin(( t - s ) * ( 2f * Mathf.PI ) / p) + 1f );
        }

        public static float InOutElastic(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            float s, a = 0.1f, p = 0.4f;
            if ( Mathf.Approximately(0, t) )
                return from;
            if ( Mathf.Approximately(1f, t) )
                return from + value;
            if ( a < 1f ) {
                a = 1f;
                s = p / 4f;
            } else
                s = p * Mathf.Asin(1f / a) / ( 2f * Mathf.PI );
            float value2;
            if ( ( t *= 2f ) < 1f )
                value2 = -0.5f * ( a * Mathf.Pow(2f, 10f * ( t -= 1f )) * Mathf.Sin(( t - s ) * ( 2f * Mathf.PI ) / p) );
            else
                value2 = a * Mathf.Pow(2f, -10f * ( t -= 1f )) * Mathf.Sin(( t - s ) * ( 2f * Mathf.PI ) / p) * 0.5f + 1f;
            return from + value * value2;
        }

        public static float InBounce(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            float value2 = 1f - OutBounce(0f, 1f, 1f - t);
            return from + value * value2;
        }

        public static float OutBounce(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            float value2;
            if ( t < ( 1f / 2.75f ) ) {

                value2 = 7.5625f * t * t;

            } else if ( t < ( 2f / 2.75f ) ) {

                value2 = 7.5625f * ( t -= ( 1.5f / 2.75f ) ) * t + 0.75f;

            } else if ( t < ( 2.5f / 2.75f ) ) {

                value2 = 7.5625f * ( t -= ( 2.25f / 2.75f ) ) * t + 0.9375f;

            } else {

                value2 = 7.5625f * ( t -= ( 2.625f / 2.75f ) ) * t + 0.984375f;
            }
            return from + value * value2;
        }

        public static float InOutBounce(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            float value2;
            if ( t < 0.5f )
                value2 = InBounce(0f, 1f, t * 2f) * 0.5f;
            else value2 = OutBounce(0f, 1f, t * 2f - 1f) * 0.5f + 0.5f;
            return from + value * value2;
        }

        public static float InBack(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            float s = 1.70158f;
            return from + value * t * t * ( ( s + 1f ) * t - s );
        }

        public static float OutBack(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            float s = 1.70158f;
            float value2 = --t * t * ( ( s + 1f ) * t + s ) + 1f;
            return from + value * value2;
        }

        public static float InOutBack(float from, float to, float t) {
            t = Mathf.Clamp01(t);
            float value = from.Difference(from, to);
            float s = 1.70158f * 1.525f;
            if ( ( t *= 2f ) < 1f )
                return from + value * 0.5f * ( t * t * ( ( s + 1 ) * t - s ) );
            return from + value * 0.5f * ( ( t -= 2f ) * t * ( ( s + 1f ) * t + s ) + 2f );
        }

        public static Func<float, float, float, float> Function(EaseType type) {
            switch ( type ) {
                case EaseType.Linear:
                    return EaseFunctions[(int)EaseType.Linear];

                case EaseType.InQuad:
                    return EaseFunctions[(int)EaseType.InQuad];

                case EaseType.OutQuad:
                    return EaseFunctions[(int)EaseType.OutQuad];

                case EaseType.InOutQuad:
                    return EaseFunctions[(int)EaseType.InOutQuad];

                case EaseType.InQuart:
                    return EaseFunctions[(int)EaseType.InQuart];

                case EaseType.OutQuart:
                    return EaseFunctions[(int)EaseType.OutQuart];

                case EaseType.InOutQuart:
                    return EaseFunctions[(int)EaseType.InOutQuart];

                case EaseType.InQuint:
                    return EaseFunctions[(int)EaseType.InQuint];

                case EaseType.OutQuint:
                    return EaseFunctions[(int)EaseType.OutQuint];

                case EaseType.InOutQuint:
                    return EaseFunctions[(int)EaseType.InOutQuint];

                case EaseType.InCubic:
                    return EaseFunctions[(int)EaseType.InCubic];

                case EaseType.OutCubic:
                    return EaseFunctions[(int)EaseType.OutCubic];

                case EaseType.InOutCubic:
                    return EaseFunctions[(int)EaseType.InOutCubic];

                case EaseType.InExpo:
                    return EaseFunctions[(int)EaseType.InExpo];

                case EaseType.OutExpo:
                    return EaseFunctions[(int)EaseType.OutExpo];

                case EaseType.InOutExpo:
                    return EaseFunctions[(int)EaseType.InOutExpo];

                case EaseType.InCirc:
                    return EaseFunctions[(int)EaseType.InCirc];

                case EaseType.OutCirc:
                    return EaseFunctions[(int)EaseType.OutCirc];

                case EaseType.InOutCirc:
                    return EaseFunctions[(int)EaseType.InOutCirc];

                case EaseType.InSine:
                    return EaseFunctions[(int)EaseType.InSine];

                case EaseType.OutSine:
                    return EaseFunctions[(int)EaseType.OutSine];

                case EaseType.InOutSine:
                    return EaseFunctions[(int)EaseType.InOutSine];

                case EaseType.InElastic:
                    return EaseFunctions[(int)EaseType.InElastic];

                case EaseType.OutElastic:
                    return EaseFunctions[(int)EaseType.OutElastic];
                case EaseType.InOutElastic:
                    return EaseFunctions[(int)EaseType.InOutElastic];

                case EaseType.InBounce:
                    return EaseFunctions[(int)EaseType.InBounce];

                case EaseType.OutBounce:
                    return EaseFunctions[(int)EaseType.OutBounce];

                case EaseType.InOutBounce:
                    return EaseFunctions[(int)EaseType.InOutBounce];

                case EaseType.InBack:
                    return EaseFunctions[(int)EaseType.InBack];

                case EaseType.OutBack:
                    return EaseFunctions[(int)EaseType.OutBack];

                case EaseType.InOutBack:
                    return EaseFunctions[(int)EaseType.InOutBack];

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}