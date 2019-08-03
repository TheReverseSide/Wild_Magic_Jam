Shader "Custom/DynamicFogOfWarMask"
{
    Properties
    {
		_LevelArt ("Level Art (RGB)", 2D) = "white" {}
        _MainTex ("Revealed Area (RGB)", 2D) = "white" {}
	}
		SubShader
	{
		Tags { "Queue" = "Transparent" "RenderType" = "Transparent" "LightMode" = "ForwardBase"}
		Blend SrcAlpha OneMinusSrcAlpha
		Lighting Off
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Lambert alpha

		sampler2D _LevelArt;
		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutput o) {
			half4 baseColor = tex2D(_MainTex, IN.uv_MainTex);
			half4 levelArt = tex2D(_LevelArt, IN.uv_MainTex);
			o.Albedo = levelArt.rgb * baseColor.b;
			o.Alpha = levelArt.a - baseColor.g;
		}
		ENDCG
    }
    FallBack "Diffuse"
}
