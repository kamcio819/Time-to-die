﻿Shader "Custom/WavesShader" {
	Properties {
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_Amplitude("Amplitude", Float) = 1
		_Wavelength("Wavelength", Float) = 10
		_Speed("Speed", Float) = 1
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows vertex:vert
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		float _Amplitude, _Wavelength, _Speed;

		void vert(inout appdata_full vertexData) 
        {
			if (vertexData.vertex.z > 0.038f) {
				float3 p = vertexData.vertex.xyz;

				float k = 2 * UNITY_PI / _Wavelength;
				float f = k * (p.x - _Speed * _Time.y);

				p.z += _Amplitude * sin(f);
				p.x += _Amplitude * cos(f);

				vertexData.vertex.xyz = p;
			}
        }

		void surf (Input IN, inout SurfaceOutputStandard o) {
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}