using System.Text;

namespace JeremyAnsel.DirectX.DirectSound;

public sealed class DsWaveFile
{
    public int Channels { get; set; }

    public int SampleRate { get; set; }

    public int BitsPerSample { get; set; }

    public int BlockAlign
    {
        get
        {
            return (this.BitsPerSample / 8) * this.Channels;
        }
    }

    public int AvgBytesPerSec
    {
        get
        {
            return this.SampleRate * this.BlockAlign;
        }
    }

    public byte[] Data { get; set; } = Array.Empty<byte>();

    public static DsWaveFile FromFile(string? fileName)
    {
        if (fileName is null)
        {
            throw new ArgumentNullException(nameof(fileName));
        }

        using (var filestream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        {
            return FromStream(filestream);
        }
    }

    public static DsWaveFile FromStream(Stream? stream)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        var wav = new DsWaveFile();

        var file = new BinaryReader(stream);

        if (Encoding.ASCII.GetString(file.ReadBytes(4)) != "RIFF")
        {
            throw new InvalidDataException();
        }

        //// file size
        file.ReadInt32();

        if (Encoding.ASCII.GetString(file.ReadBytes(4)) != "WAVE")
        {
            throw new InvalidDataException();
        }

        if (Encoding.ASCII.GetString(file.ReadBytes(4)) != "fmt ")
        {
            throw new InvalidDataException();
        }

        int fmtSize = file.ReadInt32();

        if (fmtSize < 16)
        {
            throw new InvalidDataException();
        }

        if (file.ReadInt16() != 1)
        {
            throw new NotSupportedException();
        }

        wav.Channels = file.ReadInt16();
        wav.SampleRate = file.ReadInt32();

        int avgBytesPerSec = file.ReadInt32();
        int blockAlign = file.ReadInt16();

        wav.BitsPerSample = file.ReadInt16();

        if (blockAlign != wav.BlockAlign)
        {
            throw new InvalidDataException();
        }

        if (avgBytesPerSec != wav.AvgBytesPerSec)
        {
            throw new InvalidDataException();
        }

        file.BaseStream.Seek(fmtSize - 16, SeekOrigin.Current);

        while (Encoding.ASCII.GetString(file.ReadBytes(4)) != "data")
        {
            int chunkSize = file.ReadInt32();

            file.BaseStream.Seek(chunkSize, SeekOrigin.Current);
        }

        int dataSize = file.ReadInt32();

        wav.Data = file.ReadBytes(dataSize);

        return wav;
    }

    public void Save(string? fileName)
    {
        if (fileName is null)
        {
            throw new ArgumentNullException(nameof(fileName));
        }

        using (FileStream file = new FileStream(fileName, FileMode.Create, FileAccess.Write))
        {
            this.Save(file);
        }
    }

    public void Save(Stream file)
    {
        if (file is null)
        {
            throw new ArgumentNullException(nameof(file));
        }

        var header = this.BuildHeader();

        file.Write(header, 0, header.Length);
        file.Write(this.Data, 0, this.Data.Length);
    }

    public byte[] BuildHeader()
    {
        var header = new byte[44];

        Encoding.ASCII.GetBytes("RIFF").CopyTo(header, 0);
        BitConverter.GetBytes(this.Data.Length + 36).CopyTo(header, 4);
        Encoding.ASCII.GetBytes("WAVE").CopyTo(header, 8);

        Encoding.ASCII.GetBytes("fmt ").CopyTo(header, 12);
        BitConverter.GetBytes(16).CopyTo(header, 16);
        BitConverter.GetBytes((ushort)1).CopyTo(header, 20);
        BitConverter.GetBytes((ushort)this.Channels).CopyTo(header, 22);
        BitConverter.GetBytes(this.SampleRate).CopyTo(header, 24);
        BitConverter.GetBytes(this.AvgBytesPerSec).CopyTo(header, 28);
        BitConverter.GetBytes((ushort)this.BlockAlign).CopyTo(header, 32);
        BitConverter.GetBytes((ushort)this.BitsPerSample).CopyTo(header, 34);

        Encoding.ASCII.GetBytes("data").CopyTo(header, 36);
        BitConverter.GetBytes(this.Data.Length).CopyTo(header, 40);

        return header;
    }
}
