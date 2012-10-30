class CreateRefVideoLangues < ActiveRecord::Migration
  def change
    create_table :ref_video_langues do |t|
      t.string :name

      t.timestamps
    end
  end
end
