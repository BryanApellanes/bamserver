namespace Bam.Protocol;

public interface IBamSessionStateProvider
{
    IBamSessionState GetSession(IBamContext context);
}