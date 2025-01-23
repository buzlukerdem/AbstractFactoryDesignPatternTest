using System.ComponentModel.DataAnnotations;

ComputerCreator creator = new();
Computer dragon60 = creator.CreateComputer(new DRAGON4060());
Console.WriteLine(dragon60.VideoCard.VideoCardName);

class Computer
{
    public Computer(ICPU _cpu, IVideoCard _videoCard, IRAM _ram, IStorage _storage, IMotherBoard _motherBoard, IPowerSupply _powerSupply, ICase _case)
    {
        CPU = _cpu;
        VideoCard = _videoCard;
        RAM = _ram;
        MotherBoard = _motherBoard;
        Storage = _storage;
        PowerSupply = _powerSupply;
        Case = _case;
    }
    public ICPU CPU { get; set; }
    public IVideoCard VideoCard { get; set; }
    public IRAM RAM { get; set; }
    public IMotherBoard MotherBoard { get; set; }
    public IStorage Storage { get; set; }
    public IPowerSupply PowerSupply { get; set; }
    public ICase Case { get; set; }
}

class ComputerCreator
{
    ICPU _cpu;
    IVideoCard _videoCard;
    IRAM _ram;
    IMotherBoard _motherBoard;
    IStorage _storage;
    IPowerSupply _powerSupply;
    ICase _case;
    public Computer CreateComputer(IComputerFactory computerFactory)
    {
        _cpu = computerFactory.CreateCPU();
        _videoCard = computerFactory.CreateVideoCard();
        _ram = computerFactory.CreateRAM();
        _motherBoard = computerFactory.CreateMotherBoard();
        _storage = computerFactory.CreateStorage();
        _powerSupply = computerFactory.CreatePowerSupply();
        _case = computerFactory.CreateCase();
        return new Computer(_cpu, _videoCard, _ram, _storage, _motherBoard, _powerSupply, _case);
    }
}
class DRAGON4060 : IComputerFactory
{
    public DRAGON4060()
    {
        Console.WriteLine($"{nameof(DRAGON4060)} hazır sistemi üretildi.");
    }
    public ICase CreateCase()
    {
        Case c = new Case();
        c.CaseBrand = CaseBrands.GameBooster;
        c.CaseName = "GB-G1956BB";
        return c;
    }

    public ICPU CreateCPU()
    {
        CPU cPU = new CPU();
        cPU.CPUBrand = CPUBrands.Intel;
        cPU.CPUName = "i5-12400F";
        cPU.CPUCore = "6";
        cPU.CPUThread = "12";
        cPU.CPUSpeed = "4.40GHz";
        return cPU;
    }

    public IMotherBoard CreateMotherBoard()
    {
        MotherBoard motherBoard = new MotherBoard();
        motherBoard.MotherBoardBrand = MotherBoardBrands.MSI;
        motherBoard.MotherBoardName = "MSI PRO H610M-E";
        motherBoard.MotherBoardMhz = "3200MHz";
        return motherBoard;
    }

    public IPowerSupply CreatePowerSupply()
    {
        PowerSupply powerSupply = new PowerSupply();
        powerSupply.PowerSupplyBrand = PowerSupplyBrands.GameBooster;
        powerSupply.PowerSupplyName = "GameBooster 550w1";
        powerSupply.PowerSupplyWatt = "550w";
        return powerSupply;
    }

    public IRAM CreateRAM()
    {
        RAM rAM = new RAM();
        rAM.RAMBrand = RAMBrands.GSKILL;
        rAM.RAMName = "GSKILL Ripjavs V Siyah";
        rAM.RAMMemory = "16GB";
        rAM.RAMMhz = "3200MHz";
        return rAM;
    }

    public IStorage CreateStorage()
    {
        Storage storage = new Storage();
        storage.StorageName = "MLD M300";
        storage.StorageBrand = StorageBrands.MLD;
        storage.StorageMemory = "500GB";
        return storage;
    }

    public IVideoCard CreateVideoCard()
    {
        VideoCard videoCard = new VideoCard();
        videoCard.VideoCardBrand = VideoCardBrands.MSI;
        videoCard.VideoCardName = "MSI GeForce RTX 4060 VENTUS 2X BLACK";
        videoCard.VideoCardMemory = "8GB";
        videoCard.VideoCardBit = "128 Bit";
        return videoCard;
    }
}
class PHOENIX3050 : IComputerFactory
{
    public PHOENIX3050()
    {
        Console.WriteLine($"{nameof(PHOENIX3050)} hazır sistemi üretildi.");
    }
    public ICase CreateCase()
    {
        Case c = new Case();
        c.CaseBrand = CaseBrands.PowerBoost;
        c.CaseName = "PB-PS1951B";
        return c;
    }

    public ICPU CreateCPU()
    {
        CPU cPU = new CPU();
        cPU.CPUBrand = CPUBrands.Intel;
        cPU.CPUName = "i3-13100F";
        cPU.CPUCore = "4";
        cPU.CPUThread = "8";
        cPU.CPUSpeed = "3.3GHz";
        return cPU;
    }

    public IMotherBoard CreateMotherBoard()
    {
        MotherBoard motherBoard = new MotherBoard();
        motherBoard.MotherBoardBrand = MotherBoardBrands.Asus;
        motherBoard.MotherBoardName = "ASUS PRIME H610M-K ARGB";
        motherBoard.MotherBoardMhz = "3200MHz";
        return motherBoard;
    }

    public IPowerSupply CreatePowerSupply()
    {
        PowerSupply powerSupply = new PowerSupply();
        powerSupply.PowerSupplyBrand = PowerSupplyBrands.PowerBoost;
        powerSupply.PowerSupplyName = "PowerBoost 550wPB";
        powerSupply.PowerSupplyWatt = "550w";
        return powerSupply;
    }

    public IRAM CreateRAM()
    {
        RAM rAM = new RAM();
        rAM.RAMBrand = RAMBrands.Kingston;
        rAM.RAMName = "Kingston Beast Black";
        rAM.RAMMemory = "16GB";
        rAM.RAMMhz = "3200MHz";
        return rAM;
    }

    public IStorage CreateStorage()
    {
        Storage storage = new Storage();
        storage.StorageName = "MLD M300";
        storage.StorageBrand = StorageBrands.MLD;
        storage.StorageMemory = "500GB";
        return storage;
    }

    public IVideoCard CreateVideoCard()
    {
        VideoCard videoCard = new VideoCard();
        videoCard.VideoCardBrand = VideoCardBrands.Asus;
        videoCard.VideoCardName = "ASUS DUAL GeForce RTX 3050 OC Edition";
        videoCard.VideoCardMemory = "6GB";
        videoCard.VideoCardBit = "128 Bit";
        return videoCard;
    }
}


#region IComputerFactory

interface IComputerFactory
{
    ICPU CreateCPU();
    IVideoCard CreateVideoCard();
    IRAM CreateRAM();
    IMotherBoard CreateMotherBoard();
    IStorage CreateStorage();
    IPowerSupply CreatePowerSupply();
    ICase CreateCase();
}
#endregion

#region Abstract Products
interface ICPU
{
    CPUBrands CPUBrand { get; set; }
    string CPUName { get; set; }
    string CPUCore { get; set; }
    string CPUThread { get; set; }
    string CPUSpeed { get; set; }
}
interface IVideoCard
{
    VideoCardBrands VideoCardBrand { get; set; }
    string VideoCardName { get; set; }
    string VideoCardMemory { get; set; }
    string VideoCardBit { get; set; }
}
interface IRAM
{
    RAMBrands RAMBrand { get; set; }
    string RAMName { get; set; }
    string RAMMemory { get; set; }
    string RAMMhz { get; set; }
}
interface IMotherBoard
{
    MotherBoardBrands MotherBoardBrand { get; set; }
    string MotherBoardName { get; set; }
    string MotherBoardMhz { get; set; }

}
interface IStorage
{
    StorageBrands StorageBrand { get; set; }
    string StorageName { get; set; }
    string StorageMemory { get; set; }
}
interface IPowerSupply
{
    PowerSupplyBrands PowerSupplyBrand { get; set; }
    string PowerSupplyName { get; set; }
    string PowerSupplyWatt { get; set; }
}
interface ICase
{
    CaseBrands CaseBrand { get; set; }
    string CaseName { get; set; }

}
#endregion

#region Products
class CPU : ICPU
{
    #region ctor
    //public CPU(CPUBrands _CPUBrand, string _CPUName, string _CPUCore, string _CPUThread, string _CPUSpeed)
    //{
    //    CPUBrand = _CPUBrand;
    //    CPUName = _CPUName;
    //    CPUCore = _CPUCore;
    //    CPUThread = _CPUThread;
    //    CPUSpeed = _CPUSpeed;
    //}
    #endregion

    public CPUBrands CPUBrand { get; set; }
    public string CPUName { get; set; }
    public string CPUCore { get; set; }
    public string CPUThread { get; set; }
    public string CPUSpeed { get; set; }
}
class VideoCard : IVideoCard
{
    public VideoCardBrands VideoCardBrand { get; set; }
    public string VideoCardName { get; set; }
    public string VideoCardMemory { get; set; }
    public string VideoCardBit { get; set; }
}
class RAM : IRAM
{
    public RAMBrands RAMBrand { get; set; }
    public string RAMName { get; set; }
    public string RAMMemory { get; set; }
    public string RAMMhz { get; set; }
}
class MotherBoard : IMotherBoard
{
    public MotherBoardBrands MotherBoardBrand { get; set; }
    public string MotherBoardName { get; set; }
    public string MotherBoardMhz { get; set; }
}

class Storage : IStorage
{
    public StorageBrands StorageBrand { get; set; }
    public string StorageName { get; set; }
    public string StorageMemory { get; set; }
}
class PowerSupply : IPowerSupply
{
    public PowerSupplyBrands PowerSupplyBrand { get; set; }
    public string PowerSupplyName { get; set; }
    public string PowerSupplyWatt { get; set; }
}
class Case : ICase
{
    public CaseBrands CaseBrand { get; set; }
    public string CaseName { get; set; }
}
#endregion

#region Computer Enum Types
enum CPUBrands
{
    Intel, AMD
}

enum VideoCardBrands
{
    Asus, MSI, Palit, Gainward, Gigabyte, Colorful, Sapphire, Zotac
}

enum RAMBrands
{
    Fury, Corsair, XPG, Kingston, Crucial, GSKILL, HyperX
}
enum MotherBoardBrands
{
    MSI, Asus, Gigabyte
}
enum StorageBrands
{
    Samsung, Kingston, Crucial, Sandisk, PNY, ADATA, WDGreen, MLD
}
enum PowerSupplyBrands
{
    Corsair, Hadron, Everest, GamePower, Gametech, Asus, GameBooster, PowerBoost
}
enum CaseBrands
{
    Segotep, NZXT, Corsair, Thermaltake, Asus, GameBooster, PowerBoost
}
#endregion

