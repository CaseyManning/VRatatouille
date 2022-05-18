// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/VColorOpaque" {
	Category {
	Tags { "RenderType"="Opaque" }
	Lighting Off

	SubShader {
		Pass {
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			
			struct appdata_t {
				float4 vertex : POSITION;
				fixed4 color : COLOR;
				float3 normal : NORMAL;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
				fixed4 color : COLOR;
			};

			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.color = v.color;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{

				half2 uvRamp = half2(0.5,0.5);

				half3 newColor = (0,0,0);
				
					newColor = i.color;
				

				half4 finalColor = half4(newColor.x,newColor.y,newColor.z,0);
				return finalColor;
			}
			ENDCG 
		}
	}	
}
}
