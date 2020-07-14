Shader "Unlit/Portal"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Amount ("Noise Amount", Range(0,10)) = 0
        _AngleAmount ("Angle Amount", Range(0,1000)) = 0
        _MainColor ("Main Color", Color) = (1,1,1,1)
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
            float4 _MainTex_ST;
            float _Amount;
            float _AngleAmount;
            float PI = 3.14159265359;
            fixed4 _MainColor;

            float rand(float n){return frac(sin(n) * 43758.5453123);}

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
                float2 uvD = i.uv * 2.0 - 1.0;
                // sample the texture
                float r = pow((uvD.x),2) + pow((uvD.y),2) ;
                float theta = _Time.y - r * _AngleAmount;
                float2 uv = float2(cos(theta)*i.uv.x - sin(theta)*i.uv.y, sin(theta)*i.uv.x + cos(theta)*i.uv.y);
                float randX = (rand(tex2D(_MainTex, uv).r+_Time.x)*2.0-1.0)*_Amount;
                float randY = (rand(tex2D(_MainTex, uv).r+_Time.x)*2.0-1.0)*_Amount;
                float2 UV = float2(uv.x + randX ,uv.y + randY);
                fixed4 col = tex2D(_MainTex, UV);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col * _MainColor;
            }
            ENDCG
        }
    }
}
