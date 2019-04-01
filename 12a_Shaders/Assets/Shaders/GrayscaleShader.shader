Shader "CSCI4160U/GrayscaleShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_EffectAmount ("Effect Amount", Range(0.0, 1.0)) = 0.0
    }
    SubShader
    {
		Tags { "RenderType"="Transparent" }
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _EffectAmount;

			v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
				float lum = Luminance(col.rgb);
				fixed4 grayscale = float4(lum, lum, lum, 1.0);
                return lerp(col, grayscale, _EffectAmount);
            }
            ENDCG
        }
    }
}
