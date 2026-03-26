import { useState } from 'react';
import api from '../../../services/api';
import { motion } from 'framer-motion';

export function LinkPartner({ onLinked }) {
  const [email, setEmail] = useState('');
  const [loading, setLoading] = useState(false);

  const handleLink = async (e) => {
    e.preventDefault();
    setLoading(true);
    try {
      await api.post('/partners/link', { partnerEmail: email });
      onLinked(); // Recarrega o Dashboard para mostrar os cards
    } catch (err) {
      alert(err.response?.data?.message || "Não foi possível vincular este e-mail.");
    } finally {
      setLoading(false);
    }
  };

  return (
    <motion.div 
      initial={{ opacity: 0, y: 20 }}
      animate={{ opacity: 1, y: 0 }}
      className="max-w-2xl mx-auto bg-white rounded-[3rem] p-12 shadow-2xl shadow-gray-200/50 border border-white text-center"
    >
      <div className="w-20 h-20 bg-indigo-50 rounded-3xl flex items-center justify-center mx-auto mb-8 shadow-inner">
        <span className="text-3xl">💌</span>
      </div>
      
      <h2 className="text-3xl font-serif font-medium mb-4 text-gray-800">Sincronize sua rotina</h2>
      <p className="text-gray-500 mb-10 leading-relaxed max-w-sm mx-auto">
        Digite o e-mail do seu parceiro para começarem a compartilhar seus momentos de foco.
      </p>
      
      <form onSubmit={handleLink} className="space-y-4">
        <input 
          type="email" 
          value={email} 
          onChange={(e) => setEmail(e.target.value)} 
          placeholder="parceiro@email.com"
          className="w-full bg-[#F9F9F9] border-none rounded-2xl px-8 py-5 text-center text-lg outline-none focus:ring-2 focus:ring-indigo-100 transition-all placeholder:text-gray-300"
          required 
        />
        <button 
          type="submit"
          disabled={loading}
          className="w-full bg-[#1A1A1A] text-white py-5 rounded-2xl font-bold hover:bg-black transition-all shadow-xl shadow-gray-200 disabled:opacity-50"
        >
          {loading ? "Sincronizando..." : "Enviar Convite"}
        </button>
      </form>
    </motion.div>
  );
}