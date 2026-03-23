namespace CoupleSchedule.Domain.Presence.Enums;

public class FocusLevel
{
    public static readonly FocusLevel None 
        = new(0, "Nenhum", "Sem foco definido no momento.");
    
    public static readonly FocusLevel Light 
        = new(1, "Leve", "Atividade tranquila, pode ser interrompido.");
    
    public static readonly FocusLevel Deep 
        = new(2, "Foco Total", "Concentração máxima. Não interrompa!");
    
    public int Id { get; }
    public string Name { get; }
    public string Description { get; }

    public FocusLevel(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public static FocusLevel FromId(int id) => id switch
    {
        1 => Light,
        2 => Deep,
        _ => None
    };
    
    public static IEnumerable<FocusLevel> List() =>  [Light, Deep, None];
}