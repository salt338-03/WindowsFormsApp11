using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "200MB_TextFile.txt"; // 생성할 파일 경로
        long fileSizeInBytes = 10L * 1024 * 1024; // 200MB를 바이트로 변환
        string sampleText = "This is a sample line of text for the file.\n"; // 샘플 텍스트
        long currentSize = 0; // 현재 파일 크기 추적

        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                while (currentSize < fileSizeInBytes)
                {
                    writer.Write(sampleText); // 샘플 텍스트 쓰기
                    currentSize += sampleText.Length; // 현재 파일 크기 업데이트
                }
            }

            Console.WriteLine($"200MB 텍스트 파일이 생성되었습니다: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"파일 생성 중 오류가 발생했습니다: {ex.Message}");
        }
    }
}
