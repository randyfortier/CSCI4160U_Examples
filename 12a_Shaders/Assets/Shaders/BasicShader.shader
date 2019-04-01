Shader "CSCI4160U/BasicShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Colour ("Colour", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

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

			float4 _Colour;
			sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex); // MV Transform
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);      // texture tiling/offset
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
				fixed4 colour = tex2D(_MainTex, i.uv);     // sample texture colour
				if (colour.a < 1.0) {
					colour = float4(1, 1, 1, 1);
				}
                return colour * _Colour;
            }
            ENDCG
        }
    }
}
