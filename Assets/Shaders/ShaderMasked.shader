Shader "Unlit/ShaderMasked"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _MaskTex ("Texture Mask", 2D) = "white" {}
        _Treshold ("Threshold", Range(0.0,1.0)) = 0.5
        _IntensityMask ("Intensity", Range(0.0,1.0)) = 0.1
        _ColorMask ("Color Mask", Color) = (0.0,0.0,0.0,0.0)
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType"="Transparent" }
        LOD 100
      
        Blend SrcAlpha OneMinusSrcAlpha 

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _MaskTex;
            float _Treshold;
            float4 _MainTex_ST;
            fixed4 _ColorMask;
            float _IntensityMask;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 mask = tex2D(_MaskTex, i.uv);
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv) + _IntensityMask * mask * _ColorMask;
                
                float difference = _Treshold - mask.r;
                float difference2 = _Treshold - 0.01 - mask.r;
                difference = max(0,difference);
                difference = step(difference,0.001);

                col.a = difference;
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
