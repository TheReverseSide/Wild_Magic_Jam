Shader "Custom/StaticFogOfWarMask"
{
    Properties
    {
        _Color ("Color", Color) = (0,0,0,1)
        _MainTex ("Base (RGB)", 2D) = "white" {}
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

		fixed4 _Color;
		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutput o) {
			half4 baseColor = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = _Color.rgb * baseColor.g;
			o.Alpha = _Color.a - baseColor.b;
		}
		ENDCG
    }
    FallBack "Diffuse"
}
