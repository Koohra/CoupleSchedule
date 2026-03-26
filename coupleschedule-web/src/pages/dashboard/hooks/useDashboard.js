import { useState, useEffect, useCallback } from 'react';
import api from '../../../services/api'; // Verifique se o caminho do import está correto

export const useDashboard = () => {
  const [myStatus, setMyStatus] = useState(null);
  const [partnerStatus, setPartnerStatus] = useState(null);
  const [loading, setLoading] = useState(true);
  const [needsLink, setNeedsLink] = useState(false);
  const [greeting, setGreeting] = useState('');

  useEffect(() => {
    const hour = new Date().getHours();
    if (hour < 12) setGreeting('Bom dia');
    else if (hour < 18) setGreeting('Boa tarde');
    else setGreeting('Boa noite');
  }, []);

  const fetchAllData = useCallback(async () => {
    setLoading(true);
    
    try {
      const myResponse = await api.get('/partners/my-status');
      setMyStatus(myResponse.data);
      try {
        const partnerResponse = await api.get('/partners/partner-status');
        setPartnerStatus(partnerResponse.data);
        setNeedsLink(false);
        
      } catch (partnerError) {
        console.warn("Utilizador sem parceiro vinculado. Exibindo ecrã de convite.");
        setPartnerStatus(null);
        setNeedsLink(true);
      }

    } catch (error) {
      console.error("Erro geral ao carregar dados do dashboard:", error);
    } finally {
      setLoading(false);
    }
  }, []);

  useEffect(() => {
    fetchAllData();
  }, [fetchAllData]);

  return { partnerStatus, myStatus, loading, needsLink, greeting, fetchAllData };
};