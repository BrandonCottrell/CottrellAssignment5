using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CottrellAssignment5.Services;
public class FileService : IFileService
{
    private readonly ILogger<IFileService> _logger;

    public FileService(ILogger<IFileService> logger)
    {
        _logger = logger;
    }
    public void Read()
    {
        _logger.Log(LogLevel.Information, "Reading");
        Console.WriteLine("*** I am reading");
    }

    public void Write()
    {
        _logger.Log(LogLevel.Information, "Writing");
        Console.WriteLine("*** I am writing");
    }
}
