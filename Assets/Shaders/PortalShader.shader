Shader "Custom/PortalShader" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _perspective_amount ("Perspective amount", Float) = 0.0
        _uv_divide ("UV Division", Float) = 0.0
    }
    SubShader {
        Pass {
            CGPROGRAM

            #pragma target 3.0
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            uniform sampler2D _MainTex;
            float2 _MainTex_TexelSize;
            float _perspective_amount;
            float _uv_divide;

            struct v2f {
                float4 pos : SV_POSITION;
                float4 pos_frag : TEXCOORD0;
            };

            v2f vert(appdata_base v) {
                v2f o;
                float4 clipSpacePosition = UnityObjectToClipPos(v.vertex);
                o.pos = clipSpacePosition;
                // Copy of clip space position for fragment shader
                o.pos_frag = clipSpacePosition;
                return o;
            }

            half4 frag(v2f i) : SV_Target {
                // Perspective divide (Translate to NDC - (-1, 1))
                float2 uv = i.pos_frag.xy / (i.pos_frag.w * _perspective_amount + _uv_divide) ;
                // Map -1, 1 range to 0, 1 tex coord range
                uv = (uv + float2(1.0, 1.0)) * 0.5;
                if (_ProjectionParams.x < 0.0)
                {
                    uv.y = 1.0 - uv.y;
                }

                return tex2D(_MainTex, uv);
            }
            ENDCG
        }
    }
}