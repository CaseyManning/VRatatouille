     Shader "Character/Banded Light Ramp Tex" {
         Properties {
             _MainTex ("Texture", 2D) = "white" {}
             _RampTex ("Ramp", 2D) = "white"{}
             _Color ("Color", Color) = (1,1,1,1)
             _LightCutoff("Maximum distance", Float) = 5.0
         }
         SubShader {
             Tags { "RenderType" = "Opaque" }
             CGPROGRAM
             #pragma surface surf WrapLambert
             
             uniform float _LightCutoff;
             sampler2D _RampTex;
             
             half4 LightingWrapLambert (SurfaceOutput s, half3 lightDir, half atten) {
                 half NdotL = dot (s.Normal, lightDir);
                 atten = atten * NdotL;
             
                 // Find position to lookup in ramp texture
                 float2 lookUpPos = (saturate(atten),atten);
                 
                 // Lookup value at position in the ramp texture
                 atten = (tex2D(_RampTex, lookUpPos));
                 
                 // Get the lowest value in the ramp texture
                 float lowVal = tex2D(_RampTex, float2(0,0));
                 // Check to see if the attenuation is less than the lowest value in the
                 // ramp texture
                 if(atten < lowVal)
                 {
                     atten = 0;
                 }
                 if(atten != 0) {
                    atten = 1;
                 }
                 
                 half vMax = (max(max(s.Albedo.r, s.Albedo.g), s.Albedo.b));
                 half3 colorAdjust = vMax > 0 ? s.Albedo / vMax : 1;
                 half4 c;
                 c.rgb = _LightColor0.rgb * atten * colorAdjust;
                 c.a = s.Alpha;
                 return c;
             }
         
             struct Input {
                 float2 uv_MainTex;
                 float3 viewDir;
             };
             
             sampler2D _MainTex;
             half4 _Color;
             void surf (Input IN, inout SurfaceOutput o) {
                 o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb * _Color;
                 
             }
             ENDCG
         }
         Fallback "Diffuse"
     }