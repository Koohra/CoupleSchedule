import { motion } from 'framer-motion';

export function StatusCard({ data, isMe, statusLabel, dotColor, gradient }) {
  return (
    <motion.div
      whileHover={{ y: -5, scale: 1.02 }}
      whileTap={{ scale: 0.98 }}
      className={`bg-gradient-to-br ${gradient} rounded-[2.5rem] p-8 shadow-xl shadow-gray-200/40 border border-white/60 relative group overflow-hidden`}
    >
      <div className="absolute inset-0 bg-gradient-to-br from-white/0 to-white/40 opacity-0 group-hover:opacity-100 transition-opacity duration-500" />
      
      {isMe && (
        <motion.span
          initial={{ opacity: 0, x: 20 }}
          animate={{ opacity: 1, x: 0 }}
          className="absolute top-2 right-6 text-[10px] uppercase tracking-widest text-indigo-500 font-bold bg-white/80 px-4 py-1 rounded-full border border-indigo-100 shadow-sm"
        >
          ✦ Você
        </motion.span>
      )}
      
      {/* BLOCO 1: Informações do Usuário */}
      <div className="flex items-center gap-5 mb-6">
        <motion.div
          whileHover={{ rotate: 12, scale: 1.1 }}
          className="w-16 h-16 rounded-2xl bg-white flex items-center justify-center text-indigo-500 font-serif text-2xl border-2 border-indigo-100 shadow-lg shadow-indigo-100/50"
        >
          {data?.name?.charAt(0) || '?'}
        </motion.div>
        <div>
          <h3 className="text-xl font-semibold text-gray-800">{data?.name || 'Carregando...'}</h3>
          <div className="flex items-center gap-2 mt-1">
            <motion.span
              animate={{ scale: [1, 1.2, 1] }}
              transition={{ duration: 2, repeat: Infinity }}
              className={`w-2.5 h-2.5 rounded-full ${dotColor} shadow-lg shadow-current/50`}
            />
            {/* Status fixo de conexão */}
            <span className="text-xs text-gray-500 font-medium">
              {isMe ? 'online agora' : (dotColor.includes('emerald') ? 'sincronizado ao vivo' : 'ausente')}
            </span>
          </div>
        </div>
      </div>

      {/* BLOCO 2: Atividade e Tempo */}
      <div className="space-y-3">
        <div className="flex items-center justify-between">
          <p className="text-[10px] uppercase tracking-widest text-gray-400 font-bold">Atividade</p>
          {/* Mostra o tempo da atividade apenas para o parceiro */}
          {!isMe && (
            <p className="text-[10px] text-gray-400 italic">
              iniciada {statusLabel}
            </p>
          )}
        </div>
        <p className="text-2xl font-serif font-medium leading-tight text-gray-700">
          {data?.activity || "Iniciando o dia"}
        </p>
      </div>

      {/* BLOCO 3: Nível de Foco */}
      <motion.div className="mt-8" whileHover={{ scale: 1.05 }}>
        <span className={`inline-flex items-center gap-2 px-5 py-2.5 rounded-full text-[11px] font-bold transition-all ${
          data?.focusName === 'Foco Total' ? 'bg-orange-100 text-orange-600 border border-orange-200 shadow-sm shadow-orange-100' : 
          data?.focusName === 'Leve' ? 'bg-emerald-100 text-emerald-600 border border-emerald-200 shadow-sm shadow-emerald-100' : 
          'bg-gray-100 text-gray-500 border border-gray-200'
        }`}>
          <span className="w-2 h-2 rounded-full bg-current" />
          {data?.focusName || 'Nenhum'}
        </span>
      </motion.div>
    </motion.div>
  );
}