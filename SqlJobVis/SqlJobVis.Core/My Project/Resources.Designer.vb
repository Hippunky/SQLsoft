﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.225
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("SqlJobVis.Core.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to SELECT 
        '''J.job_id, 
        '''J.name, 
        '''J.enabled, 
        '''J.delete_level, 
        '''C.name AS category 
        '''FROM dbo.sysjobs J 
        '''WITH(NOLOCK) LEFT JOIN dbo.syscategories C WITH(NOLOCK) ON C.category_id = J.category_id;
        '''                                
        '''
        '''SELECT job_id,
        '''run_status, 
        '''run_date,
        '''run_time, 
        '''run_duration 
        '''from dbo.sysjobhistory WITH(NOLOCK) WHERE step_id = 0 
        '''UNION ALL 
        '''
        '''SELECT 
        '''job_id, 
        '''4, 
        '''REPLACE(CONVERT(VARCHAR(10), start_execution_date, 120), &apos;-&apos;, &apos;&apos;), 
        '''REPLACE(SUBSTRING(CONVERT(VARCHAR(20), start_execu [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property GetJobs() As String
            Get
                Return ResourceManager.GetString("GetJobs", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to SELECT 
        '''J.job_id, 
        '''J.name, 
        '''J.enabled, 
        '''J.delete_level, 
        '''C.name AS category 
        '''FROM dbo.sysjobs J 
        '''WITH(NOLOCK) LEFT JOIN dbo.syscategories C WITH(NOLOCK) ON C.category_id = J.category_id;
        '''                                
        '''
        '''SELECT job_id,
        '''run_status, 
        '''run_date,
        '''run_time, 
        '''run_duration 
        '''from dbo.sysjobhistory WITH(NOLOCK) WHERE step_id = 0 
        '''UNION ALL 
        '''
        '''SELECT 
        '''job_id, 
        '''4, 
        '''REPLACE(CONVERT(VARCHAR(10), start_execution_date, 120), &apos;-&apos;, &apos;&apos;), 
        '''REPLACE(SUBSTRING(CONVERT(VARCHAR(20), start_execu [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property GetJobsWithActivity() As String
            Get
                Return ResourceManager.GetString("GetJobsWithActivity", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
