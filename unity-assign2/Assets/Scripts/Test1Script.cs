using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Test1Script : MonoBehaviour
{
    private string pythonPath = "C:\\Users\\name\\.conda\\envs\\csharppytest1\\python.exe"; // 가상환경의 파이썬 경로
    private string pyFilePath = "C:\\Users\\name\\unitypytest\\test1.py"; // 파이썬 스크립트 파일 경로

    private int processId;

    private void Start()
    {
        // 프로세스 정보
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = pythonPath;
        startInfo.Arguments = pyFilePath;
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardOutput = true;
        startInfo.CreateNoWindow = true;

        // 프로세스 실행
        Process process = new Process();
        process.StartInfo = startInfo;
        process.OutputDataReceived += PrintPyResult;
        process.Start();
        process.BeginOutputReadLine();
    
        // 생성된 프로세스 ID
        processId = process.Id;
    }

    private void PrintPyResult(object sender, DataReceivedEventArgs e)
    {
        // 파이썬 스크립트 출력 결과 출력
        if (!string.IsNullOrEmpty(e.Data))
        {
            UnityEngine.Debug.Log(e.Data);
        }
    }
    
    private void OnDestroy()
    {
    	// 종료 대상 프로세스
        Process process = Process.GetProcessById(processId);
    	  
    	// 프로세스 종료
    	if (process != null)
        {
            process.Kill();
        }
    }
}
