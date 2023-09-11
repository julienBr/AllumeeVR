Shader "Custom/StereoAlphaIsBlack"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _Threshold("Cutout threshold", Range(0,1)) = 0.1
        _Softness("Cutout softness", Range(0,0.5)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue" = "Transparent" }
        LOD 100

        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

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
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Threshold;
            float _Softness;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // Sample the texture for both eyes (Left and Right)
                fixed4 colLeft = tex2D(_MainTex, i.uv);
                float luminance = 0.333 * (colLeft.r + colLeft.g + colLeft.b);

                // Calculate alpha based on luminance for both eyes
                float alpha = smoothstep(_Threshold, _Threshold + _Softness, luminance);

                // Combine alpha from both eyes to create a stereo effect
                fixed4 colStereo = fixed4(colLeft.rgb, alpha);

                return colStereo;
            }
            ENDCG
        }
    }
}