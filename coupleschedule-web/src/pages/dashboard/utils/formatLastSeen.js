export function formatLastSeen(dateString) {
    if (!dateString) return "visto recentemente";
  
    const date = new Date(dateString);
    const now = new Date();
    const diffInSeconds = Math.floor((now - date) / 1000);
  
    if (diffInSeconds < 60) return "agora mesmo";
    
    const diffInMinutes = Math.floor(diffInSeconds / 60);
    if (diffInMinutes < 60) return `há ${diffInMinutes} min`;
    
    const diffInHours = Math.floor(diffInMinutes / 60);
    if (diffInHours < 24) return `há ${diffInHours} ${diffInHours === 1 ? 'hora' : 'horas'}`;
    
    const options = { day: 'numeric', month: 'short', hour: '2-digit', minute: '2-digit' };
    return `em ${date.toLocaleDateString('pt-BR', options)}`;
  }