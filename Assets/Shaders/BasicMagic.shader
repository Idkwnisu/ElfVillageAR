Shader "Custom/BasicMagic"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _Emission ("Emission", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Amount ("Noise Amount", Range(0,3)) = 0.01
        _TimeAmount ("Scroll Amount", Range(0,3)) = 0.01
    }
    SubShader
    {
        Tags {"Queue" = "Transparent" "RenderType"="Transparent" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows alpha

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0
        

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        half _Amount;
        half _TimeAmount;
        fixed4 _Color;
        fixed4 _Emission;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        float rand(float n){return frac(sin(n) * 43758.5453123);}

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float2 uv = IN.uv_MainTex + _TimeAmount * float2(_Time.x,_Time.x*1.2) + _Amount * float2(rand(IN.uv_MainTex.x + _Time.x),rand(IN.uv_MainTex.y + _Time.x));
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, uv) * _Color;
            o.Albedo = c.rgb + _Emission.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a + _Emission.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
