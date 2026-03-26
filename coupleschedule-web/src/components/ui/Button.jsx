import { motion } from 'framer-motion';

export function Button({ children, onClick, variant = 'primary', className = '', ...props }) {
  const variants = {
    primary: "bg-[#1A1A1A] text-white hover:bg-black shadow-lg shadow-gray-200",
    secondary: "bg-white text-gray-800 border border-gray-200 hover:bg-gray-50",
    ghost: "bg-transparent text-gray-600 hover:bg-gray-100"
  };

  return (
    <motion.button
      onClick={onClick}
      whileHover={{ scale: 1.02 }}
      whileTap={{ scale: 0.98 }}
      className={`px-6 py-3 rounded-2xl font-bold transition-all ${variants[variant]} ${className}`}
      {...props}
    >
      {children}
    </motion.button>
  );
}