import React, { useEffect, useState } from 'react';
import { motion } from 'framer-motion';
import { useAuth } from '../../contexts/AuthContext';
import { useDashboard } from './hooks/useDashboard';
import { usePresenceSignalR } from '../../hooks/usePresenceSignalR';
import { StatusCard } from './components/StatusCard';
import { UpdateStatus } from './components/UpdateStatus/UpdateStatus';
import { LinkPartner } from './components/LinkPartner';
import { LoadingSpinner } from '../../components/ui/LoadingSpinner';
import { formatLastSeen } from './utils/formatLastSeen'

export function Dashboard() {
  const { logout, token } = useAuth(); // Assumindo que o token venha do seu AuthContext, ou use localStorage.getItem('token')
  const { partnerStatus, myStatus, loading, needsLink, greeting, fetchAllData } = useDashboard();
  
  // 1. Inicia a conexão SignalR
  const { partnerRealTimeStatus, isConnected } = usePresenceSignalR(token);

  // 2. Estado local para o parceiro: começa com os dados do Fetch e atualiza via WebSocket
  const [livePartnerStatus, setLivePartnerStatus] = useState(null);

  useEffect(() => {
    // Quando a API normal terminar de carregar, seta o status inicial
    if (partnerStatus) {
      setLivePartnerStatus(partnerStatus);
    }
  }, [partnerStatus]);

  useEffect(() => {
    // Quando chegar uma atualização pelo SignalR, sobrescreve a tela instantaneamente!
    if (partnerRealTimeStatus) {
      setLivePartnerStatus({
        ...partnerRealTimeStatus,
        lastSeen: new Date().toISOString() // Atualiza o "visto recentemente" para o exato segundo da notificação
      });
    }
  }, [partnerRealTimeStatus]);

  if (loading) return (
    <div className="min-h-screen bg-[#F8F7F4] flex flex-col items-center justify-center font-serif">
      <LoadingSpinner />
      <p className="text-xl italic text-gray-400 mt-6 animate-pulse">sincronizando...</p>
    </div>
  );

  return (
    <div className="min-h-screen bg-[#F8F7F4] text-[#2D2D2D] font-sans selection:bg-indigo-100">
      {/* Header Estilo Glassmorphism */}
      <nav className="sticky top-0 z-50 bg-white/70 backdrop-blur-xl border-b border-gray-100 px-8 py-4">
        <div className="max-w-7xl mx-auto flex justify-between items-center">
          <span className="text-xl font-serif font-bold tracking-tight">Couple Schedule ✦</span>
          <div className="flex items-center gap-6">
            <span className="hidden md:block text-[10px] uppercase tracking-widest text-gray-400 font-bold">
              {new Intl.DateTimeFormat('pt-BR', { weekday: 'short', day: 'numeric', month: 'short' }).format(new Date())}
            </span>
            <button onClick={logout} className="text-xs font-bold hover:text-red-500 transition-colors">Sair</button>
          </div>
        </div>
      </nav>

      <main className="max-w-7xl mx-auto p-8 lg:p-12">
        <div className="mb-12">
          <h1 className="text-5xl font-serif font-medium leading-tight">
            {greeting}<span className="text-indigo-600">.</span> {myStatus?.name}
          </h1>
          <p className="text-gray-400 mt-2 italic flex items-center gap-2">
            {/* Indicador visual de conexão do SignalR */}
            <span className={`w-2 h-2 rounded-full ${isConnected ? 'bg-emerald-400 animate-pulse' : 'bg-red-400'}`} />
            {isConnected ? 'Sincronização em tempo real ativa.' : 'Tentando reconectar sincronização...'}
          </p>
        </div>

        <div className="grid grid-cols-1 lg:grid-cols-12 gap-8 items-start">
          {needsLink ? (
            <div className="lg:col-span-12">
              <LinkPartner onLinked={fetchAllData} />
            </div>
          ) : (
            <>
              {/* LADO ESQUERDO: CARDS DE STATUS */}
              <div className="lg:col-span-7 space-y-8">
                <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
                  <StatusCard 
                    data={myStatus} 
                    isMe={true} 
                    statusLabel="online agora" 
                    dotColor="bg-orange-300"
                    gradient="from-orange-50 to-amber-50"
                  />
                  {/* Usa o livePartnerStatus aqui ao invés do partnerStatus puro */}
                  <StatusCard 
                    data={livePartnerStatus} 
                    isMe={false} 
                    statusLabel={formatLastSeen(livePartnerStatus?.lastSeen)}
                    dotColor={
                      // Se foi visto há menos de 5 minutos, fica verde (online), senão fica cinza (ausente)
                      (livePartnerStatus?.lastSeen && (new Date() - new Date(livePartnerStatus.lastSeen)) / 1000 < 300) 
                        ? "bg-emerald-400" 
                        : "bg-gray-300"
                    }
                    gradient={
                      (livePartnerStatus?.lastSeen && (new Date() - new Date(livePartnerStatus.lastSeen)) / 1000 < 300)
                        ? "from-emerald-50 to-teal-50"
                        : "from-gray-50 to-slate-50"
                    }
                  />
                </div>
                {/* Placeholder para estatísticas futuras */}
                <div className="bg-white/40 p-12 rounded-[2.5rem] border border-dashed border-gray-200 text-center">
                  <p className="text-xs text-gray-400 font-medium tracking-widest uppercase">Estatísticas de foco em breve</p>
                </div>
              </div>

              {/* LADO DIREITO: FORMULÁRIO FIXO */}
              <aside className="lg:col-span-5 lg:sticky lg:top-28">
                <div className="bg-white rounded-[2.5rem] p-10 shadow-[0_8px_30px_rgb(0,0,0,0.02)] border border-gray-50">
                  <h2 className="text-[10px] uppercase tracking-[0.2em] text-gray-400 font-black mb-8">Atualizar meu status</h2>
                  <UpdateStatus onStatusUpdated={fetchAllData} />
                </div>
              </aside>
            </>
          )}
        </div>
      </main>
    </div>
  );
}
// ===== Sub-componentes =====

function LoadingState() {
  return (
    <div className="min-h-screen bg-gradient-to-br from-[#F7F6F2] via-[#F0EFEB] to-[#E8E6E1] flex flex-col items-center justify-center font-serif">
      <LoadingSpinner />
      <motion.p
        initial={{ opacity: 0 }}
        animate={{ opacity: 1 }}
        transition={{ duration: 0.5 }}
        className="text-xl italic text-gray-500 mt-6"
      >
        sincronizando...
      </motion.p>
    </div>
  );
}

function BackgroundDecorations() {
  return (
    <div className="fixed inset-0 pointer-events-none overflow-hidden">
      <div className="absolute -top-40 -right-40 w-96 h-96 bg-indigo-100/30 rounded-full blur-3xl" />
      <div className="absolute -bottom-40 -left-40 w-96 h-96 bg-orange-100/30 rounded-full blur-3xl" />
      <div className="absolute top-1/2 left-1/2 -translate-x-1/2 -translate-y-1/2 w-[800px] h-[800px] bg-gradient-radial from-white/50 to-transparent rounded-full blur-2xl" />
    </div>
  );
}

function Header({ onLogout }) {
  return (
    <motion.nav
      initial={{ y: -100 }}
      animate={{ y: 0 }}
      transition={{ duration: 0.6, ease: "easeOut" }}
      className="sticky top-0 z-50 bg-white/60 backdrop-blur-2xl border-b border-white/40 px-6 lg:px-8 py-4 shadow-lg shadow-gray-200/20"
    >
      <div className="max-w-7xl mx-auto flex justify-between items-center">
        <Logo />
        <div className="flex items-center gap-6">
          <DateBadge />
          <LogoutButton onLogout={onLogout} />
        </div>
      </div>
    </motion.nav>
  );
}

function Logo() {
  return (
    <motion.div
      className="flex items-center gap-4"
      whileHover={{ scale: 1.02 }}
    >
      <div className="w-10 h-10 rounded-2xl bg-gradient-to-br from-indigo-500 to-purple-600 flex items-center justify-center shadow-lg shadow-indigo-200">
        <span className="text-white font-serif font-bold text-lg">C</span>
      </div>
      <span className="text-xl font-serif font-bold tracking-tight bg-gradient-to-r from-indigo-600 to-purple-600 bg-clip-text text-transparent">
        Couple Schedule
      </span>
      <span className="text-indigo-400">✦</span>
    </motion.div>
  );
}

function DateBadge() {
  return (
    <motion.div
      className="hidden md:flex items-center gap-2 px-4 py-2 bg-white/50 rounded-full border border-white/60"
      whileHover={{ scale: 1.05 }}
    >
      <span className="w-2 h-2 rounded-full bg-emerald-400 animate-pulse" />
      <span className="text-[10px] uppercase tracking-widest text-gray-500 font-bold">
        {new Intl.DateTimeFormat('pt-BR', { weekday: 'short', day: 'numeric', month: 'short' }).format(new Date())}
      </span>
    </motion.div>
  );
}

function LogoutButton({ onLogout }) {
  return (
    <motion.button
      onClick={onLogout}
      whileHover={{ scale: 1.05, backgroundColor: "rgb(254, 242, 242)" }}
      whileTap={{ scale: 0.95 }}
      className="flex items-center gap-2 px-4 py-2 rounded-full text-xs font-bold text-gray-500 hover:text-red-500 transition-colors border border-transparent hover:border-red-100"
    >
      <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M17 16l4-4m0 0l-4-4m4 4H7m6 4v1a3 3 0 01-3 3H6a3 3 0 01-3-3V7a3 3 0 013-3h4a3 3 0 013 3v1" />
      </svg>
      <span className="hidden sm:inline">Sair</span>
    </motion.button>
  );
}

function GreetingSection({ greeting }) {
  return (
    <motion.div
      initial={{ opacity: 0, y: 20 }}
      animate={{ opacity: 1, y: 0 }}
      transition={{ duration: 0.6, delay: 0.2 }}
      className="mb-12"
    >
      <h1 className="text-4xl md:text-5xl lg:text-6xl font-serif font-medium leading-tight">
        <span className="bg-gradient-to-r from-indigo-600 via-purple-600 to-pink-600 bg-clip-text text-transparent">
          {greeting}
        </span>
        <span className="text-gray-800">, Miguel</span>
      </h1>
      <motion.p
        initial={{ opacity: 0 }}
        animate={{ opacity: 1 }}
        transition={{ duration: 0.6, delay: 0.4 }}
        className="text-gray-400 mt-3 italic flex items-center gap-2"
      >
        <span className="w-2 h-2 rounded-full bg-emerald-400" />
        Tudo sincronizado por aqui.
      </motion.p>
    </motion.div>
  );
}

function LeftSection({ myStatus, partnerStatus }) {
  return (
    <div className="lg:col-span-7 space-y-8">
      <motion.div
        initial={{ opacity: 0, y: 30 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 0.6, delay: 0.3 }}
        className="grid grid-cols-1 md:grid-cols-2 gap-6"
      >
        <StatusCard 
          data={myStatus} 
          isMe={true} 
          statusLabel="online agora" 
          dotColor="bg-orange-400"
          gradient="from-orange-50 to-amber-50"
        />
        <StatusCard 
          data={partnerStatus} 
          isMe={false} 
          statusLabel="visto recentemente" 
          dotColor="bg-emerald-400"
          gradient="from-emerald-50 to-teal-50"
        />
      </motion.div>

      <DailyStats />
    </div>
  );
}

function DailyStats() {
  return (
    <motion.div
      initial={{ opacity: 0, y: 30 }}
      animate={{ opacity: 1, y: 0 }}
      transition={{ duration: 0.6, delay: 0.5 }}
      className="bg-white/70 backdrop-blur-xl rounded-3xl p-6 border border-white/60 shadow-xl shadow-gray-200/30"
    >
      <div className="flex items-center justify-between mb-4">
        <h3 className="text-sm font-bold text-gray-500 uppercase tracking-widest">Resumo do Dia</h3>
        <span className="text-xs text-gray-400">{new Date().toLocaleDateString('pt-BR')}</span>
      </div>
      <div className="grid grid-cols-3 gap-4">
        <StatItem label="Foco" value="4h 32m" icon="🎯" color="indigo" />
        <StatItem label="Pausas" value="6" icon="☕" color="orange" />
        <StatItem label="Tarefas" value="12" icon="✓" color="emerald" />
      </div>
    </motion.div>
  );
}

function RightSection({ onStatusUpdated }) {
  return (
    <motion.aside
      initial={{ opacity: 0, x: 30 }}
      animate={{ opacity: 1, x: 0 }}
      transition={{ duration: 0.6, delay: 0.4 }}
      className="lg:col-span-5 sticky top-28"
    >
      <div className="bg-white/80 backdrop-blur-2xl rounded-[2.5rem] p-10 shadow-2xl shadow-gray-200/40 border border-white/60 relative overflow-hidden">
        <div className="absolute -top-20 -right-20 w-40 h-40 bg-gradient-to-br from-indigo-100 to-purple-100 rounded-full blur-2xl opacity-50" />
        
        <div className="relative z-10">
          <UpdateStatusHeader />
          <UpdateStatus onStatusUpdated={onStatusUpdated} />
        </div>
      </div>

      <ConnectionStatus />
    </motion.aside>
  );
}

function UpdateStatusHeader() {
  return (
    <div className="flex items-center gap-3 mb-8">
      <div className="w-10 h-10 rounded-2xl bg-gradient-to-br from-indigo-500 to-purple-600 flex items-center justify-center shadow-lg shadow-indigo-200">
        <svg className="w-5 h-5 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
          <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M11 5H6a2 2 0 00-2 2v11a2 2 0 002 2h11a2 2 0 002-2v-5m-1.414-9.414a2 2 0 112.828 2.828L11.828 15H9v-2.828l8.586-8.586z" />
        </svg>
      </div>
      <div>
        <h2 className="text-lg font-bold text-gray-800">Atualizar Status</h2>
        <p className="text-xs text-gray-400">Compartilhe com seu parceiro</p>
      </div>
    </div>
  );
}

function ConnectionStatus() {
  return (
    <motion.div
      initial={{ opacity: 0, y: 20 }}
      animate={{ opacity: 1, y: 0 }}
      transition={{ duration: 0.6, delay: 0.6 }}
      className="mt-6 bg-gradient-to-r from-indigo-500/10 to-purple-500/10 rounded-2xl p-6 border border-indigo-100"
    >
      <div className="flex items-center gap-3">
        <div className="relative">
          <div className="w-3 h-3 rounded-full bg-emerald-400" />
          <div className="absolute inset-0 w-3 h-3 rounded-full bg-emerald-400 animate-ping" />
        </div>
        <div>
          <p className="text-sm font-bold text-gray-700">Conexão Ativa</p>
          <p className="text-xs text-gray-400">Sincronização em tempo real</p>
        </div>
      </div>
    </motion.div>
  );
}

function Footer() {
  return (
    <motion.footer
      initial={{ opacity: 0 }}
      animate={{ opacity: 1 }}
      transition={{ duration: 0.6, delay: 0.8 }}
      className="max-w-7xl mx-auto px-8 py-8 mt-12 border-t border-gray-200/50"
    >
      <div className="flex flex-col md:flex-row justify-between items-center gap-4">
        <p className="text-xs text-gray-400">© 2026 Couple Schedule. Feito com amor ✦</p>
        <div className="flex items-center gap-6">
          <a href="#" className="text-xs text-gray-400 hover:text-indigo-500 transition-colors">Privacidade</a>
          <a href="#" className="text-xs text-gray-400 hover:text-indigo-500 transition-colors">Termos</a>
          <a href="#" className="text-xs text-gray-400 hover:text-indigo-500 transition-colors">Suporte</a>
        </div>
      </div>
    </motion.footer>
  );
}