/*
 * Copyright (c) 2012 Stephen A. Pratt
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
using UnityEngine;
using UnityEditor;
using org.critterai.u3d.editor;
using org.critterai.nmbuild.u3d.editor;

/// <summary>
/// <see cref="MeshCompiler"/> editor.
/// </summary>
[CustomEditor(typeof(MeshCompiler))]
public class MeshCompilerEditor
    : Editor
{
    /// <summary>
    /// Controls behavior of the inspector.
    /// </summary>
    public override void OnInspectorGUI()
    {
        MeshCompiler targ = (MeshCompiler)target;

        EditorGUILayout.Separator();

        GUILayout.Label("Priority: " + targ.Priority);

        EditorGUILayout.Separator();

        EditorGUIUtility.LookLikeControls(120);

        targ.colocationOption = (MeshColocationOption)
            EditorGUILayout.EnumPopup("Colocation priority", targ.colocationOption); 

        EditorGUILayout.Separator();

        GUILayout.Box("Input Build Processor\n"
            + "Loads and compiles the " + typeof(MeshFilter).Name + " components in the scene."
            , EditorUtil.HelpStyle
            , GUILayout.ExpandWidth(true));

        EditorGUILayout.Separator();

        if (GUI.changed)
            EditorUtility.SetDirty(targ);
    }

    [MenuItem(EditorUtil.NMGenAssetMenu + "Compiler : MeshFilter", false, NMBEditorUtil.CompilerGroup)]
    static void CreateAsset()
    {
        MeshCompiler item = EditorUtil.CreateAsset<MeshCompiler>(NMBEditorUtil.AssetLabel);
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = item;
    }

    //[MenuItem("CONTEXT/NavmeshBuild/New MeshFilter Compiler", true)]
    //static bool AddAssetValidate(MenuCommand command)
    //{
    //    NavmeshBuild context = (NavmeshBuild)command.context;

    //    return !context.ContainsProcessor<MeshCompiler>();
    //}

    //[MenuItem("CONTEXT/NavmeshBuild/New MeshFilter Compiler", false)]
    //static void AddAsset(MenuCommand command)
    //{
    //    NavmeshBuild context = (NavmeshBuild)command.context;

    //    InputBuildProcessor item =
    //        EditorUtil.CreateAsset<MeshCompiler>(context, NMBEditorUtil.AssetLabel);

    //    context.inputProcessors.Add(item);
    //    EditorUtility.SetDirty(context);
    //}
}
