using Sandbox.Mounting;

namespace src;

public class HL2Mount : BaseGameMount
{
    private string? Path { get; set; }

    public override string Ident { get; } = "hl2";
    public override string Title { get; } = "Half-Life 2";

    protected override void Initialize(InitializeContext context)
    {
        if (!context.IsAppInstalled(220L)) return;
        
        Path = context.GetAppDirectory(220L) + "/hl2.exe";
        
        this.IsInstalled = File.Exists(this.Path);
    }

    protected override Task Mount(MountContext context)
    {
        if (!File.Exists(this.Path))
        {
            context.AddError(this.Path + " is not installed");
            return Task.CompletedTask;
        }
        this.IsMounted = true;
        return Task.CompletedTask;
    }
}