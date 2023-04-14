using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Python.Runtime;
using UnityPython37;

public class Test2Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Python 가상환경 경로를 홈 경로로 설정
        PythonEngine.PythonHome = @"C:\Users\name\anaconda3\envs\csharppytest"; ;

        // Python 엔진 초기화
        PythonEngine.Initialize();

        // Python 코드 실행
        using (Py.GIL())
        {
            dynamic os = Py.Import("os");
            dynamic sys = Py.Import("sys");

            // Python 파일
            var python_file_path = @"C:\Users\name\source\repos\ConsoleApp1\ConsoleApp1\test2.py";
            sys.path.append(os.path.dirname(os.path.expanduser(python_file_path)));
            var fromFile = Py.Import(Path.GetFileNameWithoutExtension(python_file_path));

            // 메소드 호출
            fromFile.InvokeMethod("printTest");
        }

        // python 엔진 종료
        PythonEngine.Shutdown();
    }
}
