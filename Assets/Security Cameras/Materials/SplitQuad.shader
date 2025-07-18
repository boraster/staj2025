Shader "Unlit/CameraTV"
{
    Properties
    {
        _MainTexA ("Camera A", 2D) = "white" {}
        _MainTexB ("Camera B", 2D) = "white" {}
        _MainTexC ("Camera C", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTexA;
            sampler2D _MainTexB;
            sampler2D _MainTexC;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;

                if (uv.y > 0.66)
                    return tex2D(_MainTexA, uv * float2(1,3) - float2(0,0));
                else if (uv.y > 0.33)
                    return tex2D(_MainTexB, uv * float2(1,3) - float2(0,1));
                else
                    return tex2D(_MainTexC, uv * float2(1,3) - float2(0,2));
            }
            ENDCG
        }
    }
}
