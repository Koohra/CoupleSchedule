import { useEffect, useState } from 'react';
import * as signalR from '@microsoft/signalr';

export const usePresenceSignalR = (token) => {
  const [partnerRealTimeStatus, setPartnerRealTimeStatus] = useState(null);
  const [isConnected, setIsConnected] = useState(false);

  useEffect(() => {
    // Só tenta conectar se houver um token JWT disponível
    if (!token) return;

    // Constrói a conexão apontando para a porta do seu backend (.NET)
    const connection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:5258/hubs/presence', {
        accessTokenFactory: () => token
      })
      .withAutomaticReconnect() // Tenta reconectar sozinho se a rede cair
      .build();

    // Inicia a conexão
    connection.start()
      .then(() => {
        setIsConnected(true);
        console.log('Conectado ao Hub de Presença!');
      })
      .catch(err => console.error('Erro ao conectar no SignalR: ', err));

    // Fica escutando o evento emitido pelo IPresenceNotifier do backend
    connection.on('ReceiveStatusUpdate', (status) => {
      console.log('Novo status recebido:', status);
      setPartnerRealTimeStatus(status);
    });

    // Cleanup: desliga a conexão quando o componente for desmontado
    return () => {
      connection.off('ReceiveStatusUpdate');
      connection.stop().then(() => setIsConnected(false));
    };
  }, [token]);

  return { partnerRealTimeStatus, isConnected };
};