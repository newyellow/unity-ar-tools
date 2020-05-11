// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "newyellow/ARLightMaskRect"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_ScreenTex("ScreenTex", 2D) = "white" {}
		_Width("Width", Range( 0 , 1)) = 0.5718961
		_Height("Height", Range( 0 , 1)) = 0.5178761
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "AlphaTest+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Unlit keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float4 screenPos;
			float2 uv_texcoord;
		};

		uniform sampler2D _ScreenTex;
		uniform float _Width;
		uniform float _Height;
		uniform float _Cutoff = 0.5;

		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float4 ase_screenPos = float4( i.screenPos.xyz , i.screenPos.w + 0.00000000001 );
			float4 ase_screenPosNorm = ase_screenPos / ase_screenPos.w;
			ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
			float4 tex2DNode1 = tex2D( _ScreenTex, (ase_screenPosNorm).xy );
			float4 appendResult25 = (float4(tex2DNode1.r , tex2DNode1.g , tex2DNode1.b , 0.0));
			o.Emission = appendResult25.xyz;
			o.Alpha = 1;
			float temp_output_56_0 = ( _Width * 0.5 );
			float temp_output_61_0 = ( _Height * 0.5 );
			float clampResult62 = clamp( ( step( i.uv_texcoord.x , temp_output_56_0 ) + step( ( 1.0 - i.uv_texcoord.x ) , temp_output_56_0 ) + step( i.uv_texcoord.y , temp_output_61_0 ) + step( ( 1.0 - i.uv_texcoord.y ) , temp_output_61_0 ) ) , 0.0 , 1.0 );
			clip( clampResult62 - _Cutoff );
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18000
1935;-347;1065;1405;1403.629;952.2737;1.65532;True;False
Node;AmplifyShaderEditor.TextureCoordinatesNode;31;-1263.78,23.44298;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;45;-1312.229,490.5803;Inherit;False;Constant;_Float0;Float 0;3;0;Create;True;0;0;False;0;0.5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;36;-1397.715,719.8569;Inherit;False;Property;_Width;Width;2;0;Create;True;0;0;False;0;0.5718961;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;57;-1393.431,807.5975;Inherit;False;Property;_Height;Height;3;0;Create;True;0;0;False;0;0.5178761;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenPosInputsNode;2;-1449.113,-397.0342;Float;False;0;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;61;-906.3319,858.4653;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;56;-922.8567,375.993;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;60;-900.1663,685.8238;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;39;-924.9262,119.753;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StepOpNode;59;-638.1204,801.4318;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ComponentMaskNode;3;-1190.062,-397.0342;Inherit;False;True;True;False;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.StepOpNode;54;-660.8112,278.882;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StepOpNode;53;-657.7279,50.74804;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StepOpNode;58;-653.5349,562.5076;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;55;-321.8517,406.6632;Inherit;True;4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;1;-950.3015,-419.6761;Inherit;True;Property;_ScreenTex;ScreenTex;1;0;Create;True;0;0;False;0;-1;e7f949bb680281342aba90ea116c2b71;e7f949bb680281342aba90ea116c2b71;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ClampOpNode;62;-342.5688,125.3396;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;25;-350.1188,-324.4482;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;Float;False;True;-1;2;ASEMaterialInspector;0;0;Unlit;newyellow/ARLightMaskRect;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;True;Opaque;;AlphaTest;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;61;0;57;0
WireConnection;61;1;45;0
WireConnection;56;0;36;0
WireConnection;56;1;45;0
WireConnection;60;0;31;2
WireConnection;39;0;31;1
WireConnection;59;0;60;0
WireConnection;59;1;61;0
WireConnection;3;0;2;0
WireConnection;54;0;39;0
WireConnection;54;1;56;0
WireConnection;53;0;31;1
WireConnection;53;1;56;0
WireConnection;58;0;31;2
WireConnection;58;1;61;0
WireConnection;55;0;53;0
WireConnection;55;1;54;0
WireConnection;55;2;58;0
WireConnection;55;3;59;0
WireConnection;1;1;3;0
WireConnection;62;0;55;0
WireConnection;25;0;1;1
WireConnection;25;1;1;2
WireConnection;25;2;1;3
WireConnection;0;2;25;0
WireConnection;0;10;62;0
ASEEND*/
//CHKSM=D2157796F20C09017D966ACE69670C203F47321A