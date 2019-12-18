//Our own shader for our assets. Made by ArsKvsh from Rune Studios. 
Shader "Rune Studios/Rune's Simple Shader" {
Properties {
    _Color ("Main Color", Color) = (1,1,1,1)
    _MainTex ("Base (RGB)", 2D) = "white" {}
}
SubShader { 
    Tags { "RenderType"="Opaque" }
    LOD 800
     
CGPROGRAM
#pragma surface surf BlinnPhong
 
 
sampler2D _MainTex;
fixed4 _Color;
 
struct Input {
    float2 uv_MainTex;
};
 
void surf (Input IN, inout SurfaceOutput o) {
    fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
    o.Albedo = tex.rgb * _Color.rgb;
    o.Alpha = tex.a * _Color.a;
}
ENDCG
}
 
FallBack "Diffuse"
}
 