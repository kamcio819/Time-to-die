Shader "Custom/WindShader" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
					
		_Strength("Strength", Range(0, 2)) = 0.3
		_Frequency("Frecuency",Range(0.001,100)) = 1
		_Distance("Distance between gusts",Range(0.001,50)) = .25
	}
		SubShader{
		Tags { "Queue" = "Transparent"
		"RenderType" = "TransparentCutout"
		}
		LOD 200

		CGPROGRAM

		#pragma surface surf Standard vertex:vert alpha:fade

			sampler2D _MainTex;

			struct Input {
			float2 uv_MainTex;
			};

			half _Glossiness;
			half _Metallic;
			fixed4 _Color;

			half _Strength, _Frequency, _Distance;

			void vert(inout appdata_full vertexData)
			{
				float4 vertWorld = mul(unity_ObjectToWorld, vertexData.vertex);

				vertWorld.x += cos(_Frequency * _Time.x + vertWorld.x * _Distance) * _Strength;
				vertWorld.z += sin(_Frequency * _Time.x + vertWorld.z * _Distance) * _Strength;

				vertexData.vertex = mul(unity_WorldToObject, vertWorld);
			}

			void surf(Input IN, inout SurfaceOutputStandard o) {
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
				o.Albedo = c.rgb;
				o.Metallic = _Metallic;
				o.Smoothness = _Glossiness;
				o.Alpha = c.a;
				}
				ENDCG

		}
			FallBack "Diffuse"
}