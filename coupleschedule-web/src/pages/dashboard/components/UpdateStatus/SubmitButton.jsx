import { motion } from 'framer-motion';

export function SubmitButton() {
  return (
    <motion.button 
      type="submit" 
      whileHover={{ scale: 1.02 }}
      whileTap={{ scale: 0.98 }}
      className="w-full bg-[#1A1A1A] text-white py-5 rounded-2xl font-bold hover:bg-black transition-all shadow-lg shadow-gray-200"
    >
      Atualizar
    </motion.button>
  );
}